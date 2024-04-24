using System;
using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.AdditionalDocuments.Queries.GetAdditionalDocumentListById;
using DisabilityInPortal.ApplicationLayer.Features.AdditionalInformations.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.Addresses.Queries.GetAddressById;
using DisabilityInPortal.ApplicationLayer.Features.Affidavits;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.Companies.Queries.GetCompanyById;
using DisabilityInPortal.ApplicationLayer.Features.ContractReferences.Queries.GetContractReferencesById;
using DisabilityInPortal.ApplicationLayer.Features.DisabilityImpacts.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.Diversities.Queries.GetDiversityById;
using DisabilityInPortal.ApplicationLayer.Features.Equipments.Queries.GetEquipmentById;
using DisabilityInPortal.ApplicationLayer.Features.FinancialSizeInfo.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.ManagementAtOutsideFirm.Queries.GetManagementAtOutsideFirmById;
using DisabilityInPortal.ApplicationLayer.Features.ManagementChanges.Queries.GetManagementChangeById;
using DisabilityInPortal.ApplicationLayer.Features.ManagementContributions.Queries.GetManagementContributionById;
using DisabilityInPortal.ApplicationLayer.Features.ManagementResponsibility.Queries.GetManagementResponsibilityById;
using DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.RealEstates.Queries.GetRealEstateById;
using DisabilityInPortal.ApplicationLayer.Features.TransportationDetails.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.TrustDetails.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.Vehicles.Queries.GetVehicleById;
using DisabilityInPortal.ApplicationLayer.Features.WorkflowHistory;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById;

public class ApplicationDto
{
    public int ApplicationId { get; set; }
    public string ApplicationReference { get; set; }
    public int HowDidYouHearAboutUs { get; set; }
    public string ReferredBy { get; set; }
    public int? CompanyId { get; set; }
    public CompanyDto Company { get; set; }
    public ApplicationStatus ApplicationStatus { get; set; }
    public string UserId { get; set; }
    public List<ApplicationCertificationAgencyDto> ApplicationCertificationAgencies { get; set; }
    public RealEstateDto RealEstate { get; set; }
    public TrustDetailDto TrustDetail { get; set; }
    public AdditionalInformationDto AdditionalInformation { get; set; }
    public TransportationDetailDto TransportationDetail { get; set; }
    public CapabilityDto Capability { get; set; }
    public List<ManagementContributionDto> ManagementContributions { get; set; }
    public ManagementResponsibilityDto ManagementResponsibility { get; set; }
    public DisabilityImpactDto DisabilityImpact { get; set; }
    public ManagementAtOutsideFirmDto ManagementAtOutsideFirm { get; set; }
    public FinancialSizeInfoDto FinancialSizeInfo { get; set; }
    public ManagementChangeDto ManagementChange { get; set; }
    public AdditionalDocumentListDto AdditionalDocumentList { get; set; }
    public AffidavitDto Affidavit { get; set; }
    public PaymentDetailDto PaymentDetail { get; set; }
    public InvoiceDto Invoice { get; set; }
    public DateTimeOffset? ApplicationSubmittedDate { get; set; }
    public DateTimeOffset? ApplicationCreatedDate { get; set; }
    public DateTimeOffset? ApplicationApprovedDate { get; set; }
    public DateTimeOffset? ApplicationExpirationDate { get; set; }
    public WorkflowHistoryEventsDto WorkflowHistoryEvents { get; set; }
    public List<DiversityDto> DiversityList { get; set; }
    public List<ContractReferenceDto> ContractReferenceList { get; set; }
    public List<AddressDto> AddressList { get; set; }
    public List<EquipmentDto> Equipments { get; set; }
    public List<VehicleDto> Vehicles { get; set; }
    public int? ClonedFromApplicationId { get; set; }
}