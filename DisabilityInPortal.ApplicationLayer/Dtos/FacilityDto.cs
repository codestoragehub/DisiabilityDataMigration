using DisabilityInPortal.ApplicationLayer.Features.Addresses.Queries.GetAddressById;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.RealEstates.Queries.GetFacilityById
{
    public class FacilityDto : AddressDto
    {
        public int FacilityId { get; set; }
        public int RealEstateId { get; set; }
        public FacilityType FacilityType { get; set; }
        public OwnershipType Ownership { get; set; }
        public decimal RentalAmount { get; set; }

        public int? DocumentId { get; set; }
    }
}