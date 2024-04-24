using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("RealEstates")]
    public class RealEstate
    {
        public RealEstate()
        {
            Facilities = new List<Facility>();
        }
        
        public int RealEstateId { get; set; }
        public bool HasFullTimeOffice { get; set; }
        public bool IsHomeBusinessHeadquarters { get; set; }
        public List<Facility> Facilities { get; set; }
        
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}