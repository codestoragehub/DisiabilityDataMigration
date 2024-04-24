using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.AdditionalDocuments.Queries.GetAdditionalDocumentListById;
using DisabilityInPortal.ApplicationLayer.Features.AdditionalInformations.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById;
using DisabilityInPortal.ApplicationLayer.Features.Companies.Queries.GetCompanyById;
using DisabilityInPortal.ApplicationLayer.Features.DisabilityImpacts.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.FinancialSizeInfo.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.ManagementAtOutsideFirm.Queries.GetManagementAtOutsideFirmById;
using DisabilityInPortal.ApplicationLayer.Features.ManagementChanges.Queries.GetManagementChangeById;
using DisabilityInPortal.ApplicationLayer.Features.ManagementResponsibility.Queries.GetManagementResponsibilityById;
using DisabilityInPortal.ApplicationLayer.Features.RealEstates.Queries.GetRealEstateById;
using DisabilityInPortal.ApplicationLayer.Features.TransportationDetails.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.TrustDetails.Dtos;

namespace DisabilityInPortal.ApplicationLayer.Features.Applications.Commands.UpdateApplication
{
    public class UpdateApplicationDto
    {
        public int ApplicationId { get; set; }
        public int HowDidYouHearAboutUs { get; set; }
        public string ReferredBy { get; set; }       
        public int? CompanyId { get; set; }
        public string UserId { get; set; }
        public CompanyDto Company { get; set; }
        public List<ApplicationCertificationAgencyDto> ApplicationCertificationAgencies { get; set; }
        public RealEstateDto RealEstate { get; set; }
        public TrustDetailDto TrustDetail { get; set; }
        public AdditionalInformationDto AdditionalInformation { get; set; }
        public TransportationDetailDto TransportationDetail { get; set; }
        public CapabilityDto Capability { get; set; }
        public ManagementResponsibilityDto ManagementResponsibility { get; set; }
        public DisabilityImpactDto DisabilityImpact { get; set; }
        public ManagementAtOutsideFirmDto ManagementAtOutsideFirm { get; set; }
        public FinancialSizeInfoDto FinancialSizeInfo { get; set; }
        public ManagementChangeDto ManagementChange { get; set; }
        public AdditionalDocumentListDto AdditionalDocumentList { get; set; }
    }
}