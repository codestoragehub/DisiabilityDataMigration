using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("SupplierProfileCapabilities", Schema = "sp")]
    public class SupplierProfileCapability
    {
        public SupplierProfileCapability()
        {
            NaicsCodes = new List<NaicsCode>();
            SicCodes = new List<SicCode>();
            UkSicCodes = new List<UkSicCode>();
            UnspscCodes = new List<UnspscCode>();
            UnNumberCodes = new List<UnNumberCode>();
        }
        public int SupplierProfileCapabilityId { get; set; }
        [StringLength(1024)]
        public string ProductServiceDescription { get; set; }

        public GeographicalServiceAreaType GeographicalServiceArea { get; set; }

        public List<NaicsCode> NaicsCodes { get; set; }
        public List<SicCode> SicCodes { get; set; }
        public List<UkSicCode> UkSicCodes { get; set; }
        public List<UnspscCode> UnspscCodes { get; set; }
        public List<UnNumberCode> UnNumberCodes { get; set; }


        public int SupplierProfileId { get; set; }
        public SupplierProfile SupplierProfile { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }     

}
