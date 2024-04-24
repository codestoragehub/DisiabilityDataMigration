using System.Linq;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.ApplicationLayer.Extensions;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById;
using DisabilityInPortal.Domain.Constants;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.ApplicationLayer.Features.Applications.Commands.UpdateApplication;

public class UpdateApplicationDtoValidator : AbstractValidator<UpdateApplicationDto>
{
    private readonly IAdditionalDocumentService _additionalDocumentService;
    private readonly IAdditionalInformationService _additionalInformationService;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IApplicationService _applicationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public UpdateApplicationDtoValidator(
        UserManager<ApplicationUser> userManager,
        IApplicationRepository applicationRepository,
        IAdditionalDocumentService additionalDocumentService,
        IAdditionalInformationService additionalInformationService,
        IApplicationService applicationService)
    {
        _userManager = userManager;
        _applicationRepository = applicationRepository;
        _additionalDocumentService = additionalDocumentService;
        _additionalInformationService = additionalInformationService;
        _applicationService = applicationService;

        AddBeginApplicationSectionValidations();

        RuleFor(gi => gi.Company.LegalBusinessName)
            .NotEmpty()
            .NotNull()
            .WithName("Legal Business Name");

        RuleFor(gi => gi.Company.DoingBusinessAs)
            .NotEmpty()
            .NotNull()
            .WithName("Doing Business As");

        RuleFor(gi => gi.Company.CompanyWebsiteAddress)
            .NotEmpty()
            .NotNull()
            .WithName("Company Website Address");

        RuleFor(gi => gi.Company.IndustryType)
            .IsInEnum()
            .NotEqual(IndustryType.None)
            .WithMessage("Industry Type must not be None");

        RuleFor(gi => gi.Company.IndustryTypeOther)
            .NotEmpty()
            .NotNull()
            .When(gi => gi.Company.IndustryType == IndustryType.Other)
            .WithName("Industry Type other");

        RuleFor(gi => gi.Company.BusinessAcquisition)
            .NotEmpty()
            .NotNull()
            .WithName("Business Acquisition");

        RuleFor(gi => gi.Company.BusinessHistory)
            .NotEmpty()
            .NotNull()
            .WithName("Business History");

        RuleFor(gi => gi.Company.TaxIdType)
            .IsInEnum()
            .NotEqual(TaxIdType.None)
            .WithMessage("TaxId Type must not be None");

        RuleFor(cont => cont.Company.Contractor.DocumentId)
            .NotNull()
            .NotEmpty()
            .When(com => com.Company.IsContractorCompany)
            .WithName("License Certification document");

        RuleFor(cont => cont.Company.Contractor.LicenseNumber)
            .NotNull()
            .NotEmpty()
            .When(com => com.Company.IsContractorCompany)
            .WithName("License Number");

        RuleFor(cont => cont.Company.Contractor.TradeSpecialty)
            .NotNull()
            .NotEmpty()
            .When(com => com.Company.IsContractorCompany)
            .WithName("Trade Specialty");

        WhenAsync(async (dto, _) => !await _applicationService.IsUsaBasedCompanyAsync(dto.ApplicationId), () =>
        {
            RuleFor(a => a.Company.CountryId)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithGlobalMessage("Please select a country");

            RuleFor(gi => gi.Company.FederalTaxId)
                  .NotEmpty()
                  .NotNull()
                  .WithName("Federal Tax")
                  .Matches(@"^[\d]+$").WithMessage("This field must be a number.");

        }).Otherwise(() =>
        {
            RuleFor(a => a.Company.StateId)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithGlobalMessage("Please select a state");
        });

        When(a => a.Company.CountryId == 233, () =>
        {
            RuleFor(a => a.Company.StateId)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithGlobalMessage("Please select a state");
        });

        RuleFor(fi => fi.FinancialSizeInfo.ServicesProvided)
            .NotNull()
            .NotEmpty()
            .WithName("Services Provided");

        RuleFor(fi => fi.FinancialSizeInfo.CurrentEmployeesNo)
            .GreaterThan(0)
            .WithMessage("Employees number must be greater than 0");

        RuleFor(fi => fi.FinancialSizeInfo.DocumentId)
            .NotEmpty()
            .NotNull()
            .WithName("Employees List");

        RuleFor(fr => fr.Company.FranchiseAgreementDocument.DocumentId)
            .NotNull()
            .NotEmpty()
            .When(fi => fi.Company.IsFranchise == true)
            .WithName("Franchise Agreement document");

        AddDisabilityImpactValidations();
        AddTransportationDetailValidations();
        AddAdditionalInformationValidations();
        AddTrustDetailValidations();
        AddCapabilitiesSectionValidations();

        AddDbValidations();
    }

    private void AddDisabilityImpactValidations()
    {
        RuleFor(d => d.DisabilityImpact.ApplicantInformation)
            .NotEmpty()
            .NotNull();

        RuleFor(d => d.DisabilityImpact)
            .MustAsync(async (applicationDto, _) =>
            {
                var application =
                    await _applicationRepository.GetFullApplicationByIdAsync(applicationDto.ApplicationId);

                var isVeteran = await _applicationService.IsVeteranAsync(applicationDto.ApplicationId);

                return !isVeteran
                    ? application.DisabilityImpact.DisabilityImpactDocuments.Any()
                    : application.DisabilityImpact.DisabilityImpactDocuments.Any(d =>
                        d.DisabilityImpactDocumentType == DisabilityImpactDocumentType.DisabilityRatingsLetterDocument);
            })
            .WithMessage("Please Upload a Disability Ratings Letter Document");
    }

    private void AddDbValidations()
    {
        When(a => a.ManagementAtOutsideFirm.HasAnyManagementOutsideAtFirm.GetValueOrDefault(), () =>
        {
            RuleFor(a => a.ManagementAtOutsideFirm.HasAnyManagementOutsideAtFirm)
                .MustAsync(async (applicationDto, _, _) =>
                {
                    var application =
                        await _applicationRepository.GetFullApplicationByIdAsync(applicationDto.ApplicationId);

                    return !application.ManagementAtOutsideFirm.OutsideFirmIndividuals.IsNullOrEmpty();
                })
                .WithMessage("Please add at least one management individual at outside firm");
        });

        WhenAsync(
            async (dto, _) => await _additionalDocumentService.IsDefenceFormDocumentRequiredAsync(dto.ApplicationId),
            () =>
            {
                RuleFor(a => a.AdditionalDocumentList)
                    .MustAsync(async (applicationDto, _, _) =>
                    {
                        var application =
                            await _applicationRepository.GetFullApplicationByIdAsync(applicationDto.ApplicationId);

                        return application.AdditionalDocumentList.AdditionalDocuments.Any(d =>
                            d.Type == AdditionalDocumentType.DefenceFormDocument);
                    })
                    .WithMessage("Please upload a Defense Form Document");
            });

        WhenAsync(
            async (dto, _) => await _additionalDocumentService.IsBusinessPlanDocumentRequiredAsync(dto.ApplicationId),
            () =>
            {
                RuleFor(a => a.AdditionalDocumentList)
                    .MustAsync(async (applicationDto, _, _) =>
                    {
                        var application =
                            await _applicationRepository.GetFullApplicationByIdAsync(applicationDto.ApplicationId);

                        return application.AdditionalDocumentList.AdditionalDocuments.Any(d =>
                            d.Type == AdditionalDocumentType.BusinessPlan);
                    })
                    .WithMessage("Please upload a Business Plan Document");
            });
    }

    private void AddBeginApplicationSectionValidations()
    {
        When(a =>
        {
            return Constants.HowDidYouHearAboutUsSettings
                .Any(h =>
                    a.HowDidYouHearAboutUs == (int)h.HowDidYouHearAboutUsType && h.HasReferredBy);
        }, () => { RuleFor(a => a.ReferredBy).NotEmpty().NotNull(); });

        RuleFor(p => p.ApplicationId)
            .NotNull()
            .WithMessage("{PropertyName} must be present.");

        RuleForEach(a => a.ApplicationCertificationAgencies)
            .SetValidator(new ApplicationCertificationAgenciesValidator());
    }

    private void AddCapabilitiesSectionValidations()
    {
        RuleFor(a => a.Capability.ProductServiceDescription)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .WithName("Specific Product/Service Description");

        RuleFor(a => a.Capability.GeographicalServiceArea)
            .Must(t => t != GeographicalServiceAreaType.None)
            .WithMessage("Provide a Geographical Service Area");

        WhenAsync(
            async (dto, context, arg3) => (await _userManager.FindByIdAsync(dto.UserId)).IsUSABasedCompany,
            () =>
            {
                RuleFor(a => a.Capability.NaicsCodes)
                    .NotNull()
                    .NotEmpty()
                    .WithName("NAICS Codes");

                RuleFor(a => a.Capability.SicCodes)
                    .NotNull()
                    .NotEmpty()
                    .WithName("SIC Codes");

                RuleFor(a => a.Capability.UnspscCodes)
                    .NotNull()
                    .NotEmpty()
                    .WithName("UNSPSC Codes");
            }).Otherwise(() =>
        {
            RuleFor(a => a.Capability.UkSicCodes)
                .NotNull()
                .NotEmpty()
                .WithName("SIC Codes");

            RuleFor(a => a.Capability.UnNumberCodes)
                .NotNull()
                .NotEmpty()
                .WithName("UnNumber Codes");
        });
    }

    private void AddTrustDetailValidations()
    {
        RuleFor(x => x.TrustDetail.IsIrrevocable)
            .NotNull()
            .When(x => x.TrustDetail.IsBusinessControlledByTrust)
            .WithMessage("Must select the type of trust");

        RuleFor(x => x.TrustDetail.IsTrustee)
            .Equal(true)
            .When(x => x.TrustDetail.IsBusinessControlledByTrust &&
                       !x.TrustDetail.IsBenefactor &&
                       !x.TrustDetail.IsGrantor)
            .WithMessage("'Is Trustee' or at least one of the other options must be checked.");

        RuleFor(x => x.TrustDetail.IsGrantor)
            .Equal(true)
            .When(x => x.TrustDetail.IsBusinessControlledByTrust &&
                       !x.TrustDetail.IsBenefactor &&
                       !x.TrustDetail.IsTrustee)
            .WithMessage("'Is Grantor' or at least one of the other options must be checked.");

        RuleFor(x => x.TrustDetail.IsBenefactor)
            .Equal(true)
            .When(x => x.TrustDetail.IsBusinessControlledByTrust &&
                       !x.TrustDetail.IsGrantor &&
                       !x.TrustDetail.IsTrustee)
            .WithMessage("'Is Benefactor' or at least one of the other options must be checked.");

        RuleFor(x => x.TrustDetail.DocumentId)
            .NotNull()
            .GreaterThan(0)
            .When(x => x.TrustDetail.IsBusinessControlledByTrust)
            .WithName("Trust Details document")
            .WithMessage("Trust Details document must be uploaded");
    }

    private void AddAdditionalInformationValidations()
    {
        RuleFor(x => x.AdditionalInformation.LawsuitDocumentId)
            .NotNull()
            .GreaterThan(0)
            .When(x => x.AdditionalInformation.IsInvolvedInLawsuit)
            .WithName("Lawsuit document")
            .WithMessage("Lawsuit document must be uploaded");

        RuleFor(x => x.AdditionalInformation.BankruptcyDocumentId)
            .NotNull()
            .GreaterThan(0)
            .When(x => x.AdditionalInformation.IsInvolvedInBankruptcy)
            .WithName("Bankruptcy document")
            .WithMessage("Bankruptcy document must be uploaded.");

        RuleFor(x => x.AdditionalInformation.CertificationDenialDocumentId)
            .NotNull()
            .GreaterThan(0)
            .When(x => x.AdditionalInformation.HasBeenDeniedCertification)
            .WithName("Certification Denial document")
            .WithMessage("Certification Denial document must be uploaded");

        WhenAsync(
            async (dto, token) => !await _additionalInformationService.SkipDocumentUploadAsync(dto.ApplicationId),
            () =>
            {
                RuleFor(x => x.AdditionalInformation.SiteVisitAccomodationRequirementsDocumentId)
                    .NotNull()
                    .GreaterThan(0)
                    .When(x => x.AdditionalInformation.RequiresAccommodationsDuringSiteVisit)
                    .WithName("Site Visit Accomodation Requirements document")
                    .WithMessage("Site Visit Accomodation Requirements document must be uploaded");
            });
    }

    private void AddTransportationDetailValidations()
    {
        RuleFor(x => x.TransportationDetail.InsuranceCarrier)
            .NotNull()
            .NotEmpty()
            .Length(5, 250)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation)
            .WithName("Insurance carrier");

        RuleFor(x => x.TransportationDetail.IndependentCarrier)
            .NotNull()
            .NotEmpty()
            .Length(5, 250)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation)
            .WithName("Independent carrier");

        RuleFor(x => x.TransportationDetail.CommonCarrier)
            .NotNull()
            .NotEmpty()
            .Length(5, 250)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation)
            .WithName("Common carrier");

        RuleFor(x => x.TransportationDetail.OperatingStatus)
            .NotNull()
            .NotEmpty()
            .Length(5, 250)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation)
            .WithName("Operating status");

        RuleFor(x => x.TransportationDetail.Commodities)
            .NotNull()
            .NotEmpty()
            .Length(10, 500)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation)
            .WithName("Commodities you normally transport");

        RuleFor(x => x.TransportationDetail.IsFleetContracted)
            .Equal(true)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation &&
                       !x.TransportationDetail.IsFleetLeased &&
                       !x.TransportationDetail.IsFleetOwned)
            .WithMessage("'Is Fleet Contracted' or at least one of the other options must be checked.");

        RuleFor(x => x.TransportationDetail.IsFleetLeased)
            .Equal(true)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation &&
                       !x.TransportationDetail.IsFleetContracted &&
                       !x.TransportationDetail.IsFleetOwned)
            .WithMessage("'Is Fleet Leased' or at least one of the other options must be checked.");

        RuleFor(x => x.TransportationDetail.IsFleetOwned)
            .Equal(true)
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation &&
                       !x.TransportationDetail.IsFleetContracted &&
                       !x.TransportationDetail.IsFleetLeased)
            .WithMessage("'Is Fleet Owned' or at least one of the other options must be checked.");

        RuleFor(x => x.TransportationDetail.ContractDocumentId)
            .NotNull()
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation &&
                       x.TransportationDetail.IsFleetContracted)
            .WithMessage("Must upload contract if fleet is contracted.");

        RuleFor(x => x.TransportationDetail.LeaseDocumentId)
            .NotNull()
            .When(x => x.TransportationDetail.DoesCompanyInvolveTransportation &&
                       x.TransportationDetail.IsFleetLeased)
            .WithMessage("Must upload lease if fleet is leased.");
    }
}

internal class ApplicationCertificationAgenciesValidator : AbstractValidator<ApplicationCertificationAgencyDto>
{
    public ApplicationCertificationAgenciesValidator()
    {
        When(dto =>
        {
            return CertificationAgencies.Data.Any(c => c.CertificationAgencyId == dto.CertificationAgencyId &&
                                                       c.IsDocumentRequired && dto.Checked);
        }, () =>
        {
            RuleFor(c => c.DocumentId)
                .NotNull()
                .WithMessage("Uploading a document is required");
        });
    }
}