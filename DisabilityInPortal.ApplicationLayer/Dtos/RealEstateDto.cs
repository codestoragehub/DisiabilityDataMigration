using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.RealEstates.Queries.GetFacilityById;

namespace DisabilityInPortal.ApplicationLayer.Features.RealEstates.Queries.GetRealEstateById
{
    public class RealEstateDto
    {
        public int RealEstateId { get; set; }
        public bool HasFullTimeOffice { get; set; }
        public bool IsHomeBusinessHeadquarters { get; set; }
        public int ApplicationId { get; set; }
        
        public List<FacilityDto> Facilities { get; set; }
    }
}