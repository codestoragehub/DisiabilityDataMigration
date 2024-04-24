using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class ApplicationCloningService : IApplicationCloningService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IApplicationService _applicationService;
    private readonly ICapabilityService _capabilityService;
    private readonly IDocumentFileService _documentFileService;
    private readonly IDocumentRepository _documentRepository;
    private readonly ILogger<ApplicationCloningService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationCloningService(
        IApplicationService applicationService,
        ICapabilityService capabilityService,
        IApplicationRepository applicationRepository,
        IDocumentFileService documentFileService,
        IDocumentRepository documentRepository,
        IUnitOfWork unitOfWork,
        ILogger<ApplicationCloningService> logger)
    {
        _applicationService = applicationService;
        _capabilityService = capabilityService;
        _applicationRepository = applicationRepository;
        _documentFileService = documentFileService;
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Application> CloneFromExistingApplicationAsync(int applicationId)
    {
        var existingApplication = await _applicationRepository.GetApplicationByIdAllSubPropertiesAsync(applicationId);

        return await UtiliseNewApplicationAsync(existingApplication);
    }

    private static void UtiliseAuditBase(IAuditBaseEntity auditBaseEntity)
    {
        auditBaseEntity.DateCreated = DateTimeOffset.UtcNow;
        auditBaseEntity.DateUpdated = null;
        auditBaseEntity.UpdatedBy = null;
    }

    // @formatter:off
    private async Task<Application> UtiliseNewApplicationAsync(Application existingApplication)
    {
        var newApplication = new Application
        {
            ClonedFromApplicationId = existingApplication.ApplicationId,
            UserId = existingApplication.UserId,
            CreatedBy = existingApplication.CreatedBy,
            ReferredBy = existingApplication.ReferredBy,
            HowDidYouHearAboutUs = existingApplication.HowDidYouHearAboutUs
        };
       
        newApplication.SetApplicationReference(await _applicationService.CreateUniqueApplicationReferenceAsync());
        await _applicationRepository.InsertAsync(newApplication);
        await _unitOfWork.Commit();

        try
        {
            UtiliseAddressList(existingApplication, newApplication);
            UtiliseContractReferenceList(existingApplication, newApplication);
            UtilisePaymentDetail(newApplication);
            await UtiliseAdditionalDocumentListAsync(existingApplication, newApplication);
            await UtiliseAdditionalInformationAsync(existingApplication, newApplication);
            await UtiliseApplicationCertificationAgenciesAsync(existingApplication, newApplication);
            await UtiliseBankAndCreditReferencesAsync(existingApplication, newApplication);
            await UtiliseBusinessRelationshipsAsync(existingApplication, newApplication);
            await UtiliseCapabilityAsync(existingApplication, newApplication);
            await UtiliseCompanyAsync(existingApplication, newApplication);
            await UtiliseDisabilityImpactAsync(existingApplication, newApplication);
            await UtiliseDiversityListAsync(existingApplication, newApplication);
            await UtiliseFinancialSizeInfoAsync(existingApplication, newApplication);
            await UtiliseManagementAtOutsideFirmAsync(existingApplication, newApplication);
            await UtiliseManagementChangeAsync(existingApplication, newApplication);
            await UtiliseManagementResponsibilityAsync(existingApplication, newApplication);
            await UtiliseOwnersAsync(existingApplication, newApplication);
            await UtiliseRealEstateAsync(existingApplication, newApplication);
            await UtiliseTransportationDetailAsync(existingApplication, newApplication);
            await UtiliseTrustDetailAsync(existingApplication, newApplication);
            await UtiliseEquipmentsAsync(existingApplication, newApplication);
            await UtiliseVehiclesAsync(existingApplication, newApplication);

            await _applicationRepository.UpdateAsync(newApplication);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "");
            await _applicationRepository.DeleteAsync(newApplication);
            
            return null;
        }
        finally
        {
            await _unitOfWork.Commit();
        }

        return newApplication;
    }

    private async Task<Document> UtiliseDocumentAsync(int? documentId, Application newApplication)
    {
        if (!documentId.HasValue)
            return null;

        try
        {
            var existingDocument = await _documentRepository.GetByIdAsync(documentId.Value);

            var newDocument = new Document
            {
                ApplicationId = newApplication.ApplicationId,
                Application = newApplication,
                CompanyId = newApplication.CompanyId,
                Company = newApplication.Company,
                Type = existingDocument.Type,
                ApplicationUser = existingDocument.ApplicationUser,
                CreatedBy = existingDocument.CreatedBy,
                FileName = existingDocument.FileName,
                UserId = existingDocument.UserId
            };

            await _documentRepository.InsertAsync(newDocument);
            await _unitOfWork.Commit();
            await _documentFileService.TransferAzureBlobToAzureBlobAsync(existingDocument, newDocument);

            return newDocument;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static void UtiliseAddress(Address address, Application newApplication)
    {
        UtiliseAuditBase(address);
        address.AddressId = 0;
        address.ApplicationId = newApplication.ApplicationId;
        address.Application = newApplication;
        address.CompanyId = newApplication.CompanyId;
        address.Company = newApplication.Company;

        newApplication.AddressList.Add(address);
    }

    private static void UtiliseAddressList(Application existingApplication, Application application)
    {
        var applicationAddressTypes = new[]
        {
            AddressType.CompanyContact,
            AddressType.HeadquartersInformation,
            AddressType.MailingAddress,
            AddressType.PrimaryOwnerContact
        };

        var addresses = existingApplication.AddressList.Where(a => applicationAddressTypes.Contains(a.AddressType));
        foreach (var address in addresses)
            UtiliseAddress(address, application);
    }

    private async Task UtiliseCapabilityAsync(Application existingApplication, Application newApplication)
    {
        IList<string> GetStringCodes<T>(IEnumerable<T> codes) where T : ICode, new()
        {
            return codes.Select(c => c.Code).ToList();
        }

        await _capabilityService.UpdateNaicsCodesAsync(
            newApplication,
            GetStringCodes(existingApplication.Capability.NaicsCodes));

        await _capabilityService.UpdateSicCodesAsync(
            newApplication,
            GetStringCodes(existingApplication.Capability.SicCodes));

        await _capabilityService.UpdateUnspscCodesAsync(
            newApplication,
            GetStringCodes(existingApplication.Capability.UnspscCodes));

        await _capabilityService.UpdateUkSicCodesAsync(
            newApplication,
            GetStringCodes(existingApplication.Capability.UkSicCodes));
        
        await _capabilityService.UpdateUnNumberCodesAsync(
            newApplication,
            GetStringCodes(existingApplication.Capability.UnNumberCodes));

        newApplication.Capability.GeographicalServiceArea = existingApplication.Capability.GeographicalServiceArea;
        newApplication.Capability.ProductServiceDescription = existingApplication.Capability.ProductServiceDescription;
    }

    private static void UtiliseContractReferenceList(Application existingApplication, Application newApplication)
    {
        void UtiliseContractReference(ContractReference contractReference)
        {
            contractReference.ContractReferenceId = 0;
            contractReference.ApplicationId = newApplication.ApplicationId;
            contractReference.Application = newApplication;
            UtiliseAddress(contractReference.Address, newApplication);
            contractReference.AddressId = null;

            newApplication.ContractReferenceList.Add(contractReference);
        }

        existingApplication.ContractReferenceList.ForEach(UtiliseContractReference);
    }

    private static void UtiliseManagementContributions(Application existingApplication, Application newApplication)
    {
        Owner FindClonedOwner(IEnumerable<Owner> newApplicationOwners, Owner existingOwner)
        {
            return newApplicationOwners
                .FirstOrDefault(o => o.Name == existingOwner.Name && 
                                     o.Title == existingOwner.Title && 
                                     o.DailyManagement == existingOwner.DailyManagement && 
                                     o.DisabilityStatus == existingOwner.DisabilityStatus &&
                                     o.ParticipatesShareVoting == existingOwner.ParticipatesShareVoting &&
                                     o.USCitizen == existingOwner.USCitizen &&
                                     o.IsLGBT == existingOwner.IsLGBT &&
                                     o.Ethinicity == existingOwner.Ethinicity &&
                                     o.EthinicityOther == existingOwner.EthinicityOther &&
                                     o.Gender == existingOwner.Gender && 
                                     o.GenderOther == existingOwner.GenderOther &&
                                     o.Ownership == existingOwner.Ownership);
        }
        
        void UtiliseManagementContribution(ManagementContribution managementContribution)
        {
            managementContribution.OwnerId = 0;
            managementContribution.Owner = FindClonedOwner(newApplication.Owners, managementContribution.Owner);
            
            managementContribution.ManagementContributionId = 0;
            managementContribution.ApplicationId = newApplication.ApplicationId;
            managementContribution.Application = newApplication;
            UtiliseAuditBase(managementContribution);

            newApplication.ManagementContributions.Add(managementContribution);
        }

        existingApplication.ManagementContributions.ForEach(UtiliseManagementContribution);
    }

    private static void UtilisePaymentDetail(Application application)
    {
        application.PaymentDetail.IsRecertification = true;
    }

    private async Task UtiliseAdditionalDocumentListAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseAdditionalDocumentAsync(AdditionalDocument additionalDocument)
        {
            additionalDocument.AdditionalDocumentId = 0;
            additionalDocument.AdditionalDocumentListId = newApplication.AdditionalDocumentList.AdditionalDocumentListId;
            additionalDocument.AdditionalDocumentList = newApplication.AdditionalDocumentList;

            var document = await UtiliseDocumentAsync(additionalDocument.DocumentId, newApplication);
            additionalDocument.Document = document;
            additionalDocument.DocumentId = document?.DocumentId;

            newApplication.AdditionalDocumentList.AdditionalDocuments.Add(additionalDocument);
        }

        foreach (var additionalDocument in existingApplication.AdditionalDocumentList.AdditionalDocuments)
            await UtiliseAdditionalDocumentAsync(additionalDocument);
    }

    private async Task UtiliseAdditionalInformationAsync(Application existingApplication, Application newApplication)
    {
        var bankruptcyDocument = await UtiliseDocumentAsync(
            existingApplication.AdditionalInformation.BankruptcyDocumentId,
            newApplication);

        newApplication.AdditionalInformation.BankruptcyDocument = bankruptcyDocument;
        newApplication.AdditionalInformation.BankruptcyDocumentId = bankruptcyDocument?.DocumentId;

        var lawsuitDocument = await UtiliseDocumentAsync(
            existingApplication.AdditionalInformation.LawsuitDocumentId,
            newApplication);

        newApplication.AdditionalInformation.LawsuitDocument = lawsuitDocument;
        newApplication.AdditionalInformation.LawsuitDocumentId = lawsuitDocument?.DocumentId;

        var certificationDenialDocument = await UtiliseDocumentAsync(
            existingApplication.AdditionalInformation.CertificationDenialDocumentId,
            newApplication);

        newApplication.AdditionalInformation.CertificationDenialDocument = certificationDenialDocument;
        newApplication.AdditionalInformation.CertificationDenialDocumentId = certificationDenialDocument?.DocumentId;

        var siteVisitAccomodationReqDocument = await UtiliseDocumentAsync(
            existingApplication.AdditionalInformation.SiteVisitAccomodationRequirementsDocumentId,
            newApplication);

        newApplication.AdditionalInformation.SiteVisitAccomodationRequirementsDocument = siteVisitAccomodationReqDocument;
        newApplication.AdditionalInformation.SiteVisitAccomodationRequirementsDocumentId = siteVisitAccomodationReqDocument?.DocumentId;
    }

    private async Task UtiliseApplicationCertificationAgenciesAsync(
        Application existingApplication,
        Application newApplication)
    {
        async Task UtiliseApplicationCertificationAgency(ApplicationCertificationAgency applicationCertificationAgency)
        {
            applicationCertificationAgency.ApplicationCertificationAgencyId = 0;
            applicationCertificationAgency.ApplicationId = newApplication.ApplicationId;
            applicationCertificationAgency.Application = newApplication;

            var document = await UtiliseDocumentAsync(applicationCertificationAgency.DocumentId, newApplication);
            applicationCertificationAgency.Document = document;
            applicationCertificationAgency.DocumentId = document?.DocumentId;

            UtiliseAuditBase(applicationCertificationAgency);
            newApplication.ApplicationCertificationAgencies.Add(applicationCertificationAgency);
        }

        foreach (var applicationCertificationAgency in existingApplication.ApplicationCertificationAgencies)
            await UtiliseApplicationCertificationAgency(applicationCertificationAgency);
    }

    private async Task UtiliseBankAndCreditReferencesAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference)
        {
            bankAndCreditReference.BankAndCreditReferenceId = 0;
            bankAndCreditReference.ApplicationId = newApplication.ApplicationId;
            bankAndCreditReference.Application = newApplication;

            UtiliseAddress(bankAndCreditReference.Address, newApplication);
            bankAndCreditReference.AddressId = null;

            var document = await UtiliseDocumentAsync(bankAndCreditReference.DocumentId, newApplication);
            bankAndCreditReference.Document = document;
            bankAndCreditReference.DocumentId = document?.DocumentId;

            newApplication.BankAndCreditReferences.Add(bankAndCreditReference);
        }

        foreach (var bankAndCreditReference in existingApplication.BankAndCreditReferences)
            await UtiliseBankAndCreditReferenceAsync(bankAndCreditReference);
    }

    private async Task UtiliseBusinessRelationshipsAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseBusinessRelationshipAsync(BusinessRelationship businessRelationship)
        {
            businessRelationship.BusinessRelationshipId = 0;
            businessRelationship.ApplicationId = newApplication.ApplicationId;
            businessRelationship.Application = newApplication;

            UtiliseAddress(businessRelationship.Address, newApplication);
            businessRelationship.AddressId = null;

            var document = await UtiliseDocumentAsync(businessRelationship.DocumentId, newApplication);
            businessRelationship.Document = document;
            businessRelationship.DocumentId = document?.DocumentId;

            newApplication.BusinessRelationships.Add(businessRelationship);
        }

        foreach (var businessRelationship in existingApplication.BusinessRelationships)
            await UtiliseBusinessRelationshipAsync(businessRelationship);
    }

    private async Task UtiliseCompanyAsync(Application existingApplication, Application newApplication)
    {
        newApplication.Company.LegalBusinessName = existingApplication.Company.LegalBusinessName;
        newApplication.Company.DoingBusinessAs = existingApplication.Company.DoingBusinessAs;
        newApplication.Company.FormerCompanyNames = existingApplication.Company.FormerCompanyNames;
        newApplication.Company.CompanyWebsiteAddress = existingApplication.Company.CompanyWebsiteAddress;
        newApplication.Company.TaxIdType = existingApplication.Company.TaxIdType;
        newApplication.Company.FederalTaxId = existingApplication.Company.FederalTaxId;
        newApplication.Company.BusinessAcquisitionType = existingApplication.Company.BusinessAcquisitionType;
        newApplication.Company.IsBusinessStartedByCurrentOwnership = existingApplication.Company.IsBusinessStartedByCurrentOwnership;
        newApplication.Company.BusinessHistory = existingApplication.Company.BusinessHistory;
        newApplication.Company.IndustryType = existingApplication.Company.IndustryType;
        newApplication.Company.IndustryTypeOther = existingApplication.Company.IndustryTypeOther;
        newApplication.Company.StateId = existingApplication.Company.StateId;
        newApplication.Company.CountryId = existingApplication.Company.CountryId;
        newApplication.Company.IsFranchise = existingApplication.Company.IsFranchise;
        newApplication.Company.IsContractorCompany = existingApplication.Company.IsContractorCompany;
        newApplication.Company.UserId = existingApplication.Company.UserId;

        foreach (var document in existingApplication.Company.Documents)
            await UtiliseDocumentAsync(document.DocumentId, newApplication);

        async Task UtiliseCompanyContractorAsync(Contractor contractor)
        {
            newApplication.Company.Contractor.CompanyId = newApplication.CompanyId;
            newApplication.Company.Contractor.Company = newApplication.Company;
            newApplication.Company.Contractor.LicenseNumber = contractor.LicenseNumber;
            newApplication.Company.Contractor.TradeSpecialty = contractor.TradeSpecialty;

            var document = await UtiliseDocumentAsync(contractor.DocumentId, newApplication);
            newApplication.Company.Contractor.Document = document;
            newApplication.Company.Contractor.DocumentId = document?.DocumentId;
        }

        await UtiliseCompanyContractorAsync(existingApplication.Company.Contractor);

       
        await UtiliseLegalStructureListAsync(existingApplication, newApplication);
    }

    private async Task UtiliseDisabilityImpactAsync(Application existingApplication, Application newApplication)
    {
        newApplication.DisabilityImpact.ApplicantInformation = existingApplication.DisabilityImpact.ApplicantInformation;
        newApplication.DisabilityImpact.ApplicationId = newApplication.ApplicationId;

        async Task UtiliseDisabilityImpactDocumentAsync(DisabilityImpactDocument disabilityImpactDocument)
        {
            UtiliseAuditBase(disabilityImpactDocument);
            disabilityImpactDocument.DisabilityImpactDocumentId = 0;
            disabilityImpactDocument.DisabilityImpactId = newApplication.DisabilityImpact.DisabilityImpactId;
            disabilityImpactDocument.ApplicationId = newApplication.ApplicationId;

            var document = await UtiliseDocumentAsync(disabilityImpactDocument.DocumentId, newApplication);
            disabilityImpactDocument.Document = document;
            disabilityImpactDocument.DocumentId = document?.DocumentId;
            newApplication.DisabilityImpact.DisabilityImpactDocuments.Add(disabilityImpactDocument);
        }
        foreach (var disabilityImpactDocument in existingApplication.DisabilityImpact.DisabilityImpactDocuments)
            await UtiliseDisabilityImpactDocumentAsync(disabilityImpactDocument);
    }

    private async Task UtiliseDiversityListAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseDiversityAsync(Diversity diversity)
        {
            UtiliseAuditBase(diversity);
            diversity.DiversityId = 0;
            diversity.ApplicationId = newApplication.ApplicationId;
            diversity.Application = newApplication;

            var document = await UtiliseDocumentAsync(diversity.DocumentId, newApplication);
            diversity.Document = document;
            diversity.DocumentId = document?.DocumentId;

            newApplication.DiversityList.Add(diversity);
        }

        foreach (var diversity in existingApplication.DiversityList)
            await UtiliseDiversityAsync(diversity);
    }

    private async Task UtiliseFinancialSizeInfoAsync(Application existingApplication, Application newApplication)
    {
        var document = await UtiliseDocumentAsync(
            existingApplication.FinancialSizeInfo.DocumentId,
            newApplication);

        newApplication.FinancialSizeInfo.Document = document;
        newApplication.FinancialSizeInfo.DocumentId = document?.DocumentId;
        
        newApplication.FinancialSizeInfo.ServicesProvided =existingApplication.FinancialSizeInfo.ServicesProvided;
        newApplication.FinancialSizeInfo.IndustryType =existingApplication.FinancialSizeInfo.IndustryType;
        newApplication.FinancialSizeInfo.IndustryTypeOther =existingApplication.FinancialSizeInfo.IndustryTypeOther;
        newApplication.FinancialSizeInfo.CurrentEmployeesNo =existingApplication.FinancialSizeInfo.CurrentEmployeesNo;

        async Task UtiliseIncome(Income income)
        {
            income.IncomeId = 0;

            var incomeDocument = await UtiliseDocumentAsync(income.DocumentId, newApplication);
            income.Document = incomeDocument;
            income.DocumentId = incomeDocument?.DocumentId;
            income.FinancialSizeInfoId = newApplication.FinancialSizeInfo.FinancialSizeInfoId;
            income.FinancialSizeInfo = newApplication.FinancialSizeInfo;

            newApplication.FinancialSizeInfo.Incomes.Add(income);
        }

        foreach (var income in existingApplication.FinancialSizeInfo.Incomes)
            await UtiliseIncome(income);
    }

    private async Task UtiliseManagementAtOutsideFirmAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual)
        {
            outsideFirmIndividual.OutsideFirmIndividualId = 0;
            outsideFirmIndividual.ManagementAtOutsideFirmId =
                newApplication.ManagementAtOutsideFirm.ManagementAtOutsideFirmId;
            outsideFirmIndividual.ManagementAtOutsideFirm = newApplication.ManagementAtOutsideFirm;

            var document = await UtiliseDocumentAsync(outsideFirmIndividual.DocumentId, newApplication);
            outsideFirmIndividual.Document = document;
            outsideFirmIndividual.DocumentId = document?.DocumentId;

            UtiliseAuditBase(outsideFirmIndividual);
            newApplication.ManagementAtOutsideFirm.OutsideFirmIndividuals.Add(outsideFirmIndividual);
        }

        foreach (var outsideFirmIndividual in existingApplication.ManagementAtOutsideFirm.OutsideFirmIndividuals)
            await UtiliseOutsideFirmIndividualAsync(outsideFirmIndividual);
    }

    private async Task UtiliseManagementChangeAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseManagementChangeAgreement(ManagementChangeAgreement managementChangeAgreement)
        {
            managementChangeAgreement.ManagementChangeAgreementId = 0;
            managementChangeAgreement.ManagementChangeId = newApplication.ManagementChange.ManagementChangeId;
            managementChangeAgreement.ManagementChange = newApplication.ManagementChange;

            var document = await UtiliseDocumentAsync(managementChangeAgreement.DocumentId, newApplication);
            managementChangeAgreement.Document = document;
            managementChangeAgreement.DocumentId = document?.DocumentId;

            UtiliseAuditBase(managementChangeAgreement);
            newApplication.ManagementChange.ManagementChangeAgreements.Add(managementChangeAgreement);
        }

        foreach (var managementChangeAgreement in existingApplication.ManagementChange.ManagementChangeAgreements)
            await UtiliseManagementChangeAgreement(managementChangeAgreement);
    }

    private async Task UtiliseManagementResponsibilityAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseManagementResponsibilityOwnerAsync(ManagementResponsibilityOwner responsibilityOwner)
        {
            responsibilityOwner.ManagementResponsibilityOwnerId = 0;
            responsibilityOwner.ManagementResponsibilityId = newApplication.ManagementResponsibility.ManagementResponsibilityId;
            responsibilityOwner.ManagementResponsibility = newApplication.ManagementResponsibility;
            
            var document = await UtiliseDocumentAsync(responsibilityOwner.DocumentId, newApplication);
            responsibilityOwner.Document = document;
            responsibilityOwner.DocumentId = document?.DocumentId;
            
            UtiliseAuditBase(responsibilityOwner);
            newApplication.ManagementResponsibility.ManagementResponsibilityOwners.Add(responsibilityOwner);
        }
        
        foreach (var responsibilityOwner in existingApplication.ManagementResponsibility.ManagementResponsibilityOwners)
            await UtiliseManagementResponsibilityOwnerAsync(responsibilityOwner);
    }
    
    private async Task UtiliseOwnersAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseOwnerAsync(Owner owner)
        {
            var document = await UtiliseDocumentAsync(owner.DocumentId, newApplication);
            owner.Document = document;
            owner.DocumentId = document?.DocumentId;

            owner.OwnerId = 0;
            owner.Application = newApplication;
            owner.ApplicationId = newApplication.ApplicationId;

            newApplication.Owners.Add(owner);
        }

        foreach (var owner in existingApplication.Owners)
            await UtiliseOwnerAsync(owner);
        
        UtiliseManagementContributions(existingApplication, newApplication);
    }

    private async Task UtiliseRealEstateAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseFacilityAsync(Facility facility)
        {
            facility.FacilityId = 0;
            facility.RealEstateId = newApplication.RealEstate.RealEstateId;
            facility.RealEstate = newApplication.RealEstate;
            UtiliseAddress(facility.Address, newApplication);
            facility.AddressId = null;

            var document = await UtiliseDocumentAsync(facility.DocumentId, newApplication);
            facility.Document = document;
            facility.DocumentId = document?.DocumentId;

            newApplication.RealEstate.Facilities.Add(facility);
        }

        foreach (var facility in existingApplication.RealEstate.Facilities)
            await UtiliseFacilityAsync(facility);
    }

    private async Task UtiliseTransportationDetailAsync(Application existingApplication, Application newApplication)
    {
        newApplication.TransportationDetail.Commodities = existingApplication.TransportationDetail.Commodities;
        newApplication.TransportationDetail.CommonCarrier = existingApplication.TransportationDetail.CommonCarrier;
        newApplication.TransportationDetail.IndependentCarrier = existingApplication.TransportationDetail.IndependentCarrier;
        newApplication.TransportationDetail.InsuranceCarrier = existingApplication.TransportationDetail.InsuranceCarrier;
        newApplication.TransportationDetail.OperatingStatus = existingApplication.TransportationDetail.OperatingStatus;
        newApplication.TransportationDetail.IsFleetContracted = existingApplication.TransportationDetail.IsFleetContracted;
        newApplication.TransportationDetail.IsFleetLeased = existingApplication.TransportationDetail.IsFleetLeased;
        newApplication.TransportationDetail.IsFleetOwned = existingApplication.TransportationDetail.IsFleetOwned;
        newApplication.TransportationDetail.DoesCompanyInvolveTransportation = existingApplication.TransportationDetail.DoesCompanyInvolveTransportation;

        var contractDocument = await UtiliseDocumentAsync(
            existingApplication.TransportationDetail.ContractDocumentId,
            newApplication);

        newApplication.TransportationDetail.ContractDocument = contractDocument;
        newApplication.TransportationDetail.ContractDocumentId = contractDocument?.DocumentId;

        var leaseDocument = await UtiliseDocumentAsync(
            existingApplication.TransportationDetail.LeaseDocumentId,
            newApplication);

        newApplication.TransportationDetail.LeaseDocument = leaseDocument;
        newApplication.TransportationDetail.LeaseDocumentId = leaseDocument?.DocumentId;
    }

    private async Task UtiliseTrustDetailAsync(Application existingApplication, Application newApplication)
    {
        newApplication.TrustDetail.IsBenefactor = existingApplication.TrustDetail.IsBenefactor;
        newApplication.TrustDetail.IsGrantor = existingApplication.TrustDetail.IsGrantor;
        newApplication.TrustDetail.IsIrrevocable = existingApplication.TrustDetail.IsIrrevocable;
        newApplication.TrustDetail.IsTrustee = existingApplication.TrustDetail.IsTrustee;
        newApplication.TrustDetail.IsBusinessControlledByTrust = existingApplication.TrustDetail.IsBusinessControlledByTrust;

        var document = await UtiliseDocumentAsync(existingApplication.TrustDetail.DocumentId, newApplication);
        newApplication.TrustDetail.Document = document;
        newApplication.TrustDetail.DocumentId = document?.DocumentId;
    }

    private async Task UtiliseVehiclesAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseVehicleAsync(Vehicle vehicle)
        {
            var document = await UtiliseDocumentAsync(vehicle.DocumentId, newApplication);
            vehicle.Document = document;
            vehicle.DocumentId = document?.DocumentId;

            vehicle.VehicleId = 0;
            vehicle.Application = newApplication;
            vehicle.ApplicationId = newApplication.ApplicationId;
            UtiliseAuditBase(vehicle);

            newApplication.Vehicles.Add(vehicle);
        }

        foreach (var vehicle in existingApplication.Vehicles)
            await UtiliseVehicleAsync(vehicle);
    }

    private async Task UtiliseEquipmentsAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseEquipmentAsync(Equipment equipment)
        {
            var document = await UtiliseDocumentAsync(equipment.DocumentId, newApplication);
            equipment.Document = document;
            equipment.DocumentId = document?.DocumentId;

            equipment.EquipmentId = 0;
            equipment.Application = newApplication;
            equipment.ApplicationId = newApplication.ApplicationId;

            UtiliseAuditBase(equipment);

            newApplication.Equipments.Add(equipment);
        }

        foreach (var equipment in existingApplication.Equipments)
            await UtiliseEquipmentAsync(equipment);
    }

    // @formatter:on
    private async Task UtiliseLegalStructureDocumentListAsync(LegalStructureDocument legalStructureDocument, Application newApplication)
    {
      
            legalStructureDocument.LegalStructureDocumentId = 0;
            legalStructureDocument.CompanyId = newApplication.CompanyId;
            legalStructureDocument.Company = newApplication.Company;

            var document = await UtiliseDocumentAsync(legalStructureDocument.DocumentId, newApplication);
            legalStructureDocument.Document = document;
            legalStructureDocument.DocumentId = document?.DocumentId;
    }
    private async Task UtiliseLegalStructureListAsync(Application existingApplication, Application newApplication)
    {
        async Task UtiliseLegalStructureAsync(LegalStructure legalStructure)
        {
            legalStructure.LegalStructureId = 0;
            legalStructure.CompanyId = newApplication.CompanyId;
            legalStructure.Company = newApplication.Company;

            legalStructure.ApplicationId = newApplication.ApplicationId;
            legalStructure.Application = newApplication;

            foreach (var legalStructureDocument in legalStructure.LegalStructureDocuments)
            {
                await UtiliseLegalStructureDocumentListAsync(legalStructureDocument, newApplication);
            }                

            newApplication.Company.LegalStructureList.Add(legalStructure);

        }
        foreach (var legalStructure in existingApplication.Company.LegalStructureList)
            await UtiliseLegalStructureAsync(legalStructure);
    }
}