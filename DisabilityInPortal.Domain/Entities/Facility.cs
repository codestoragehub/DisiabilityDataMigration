using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("Facilities")]
    public class Facility
    {
        public int FacilityId { get; set; }
        public FacilityType FacilityType { get; set; }
        public OwnershipType Ownership { get; set; }
        public decimal RentalAmount { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public int? DocumentId { get; set; }
        public Document Document { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}