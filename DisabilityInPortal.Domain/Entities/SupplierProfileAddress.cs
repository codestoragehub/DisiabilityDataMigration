using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using DisabilityInPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("SupplierProfileAddresses", Schema ="sp")]
    public class SupplierProfileAddress: IAddress
    {
        [Key]
        public int AddressId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        public AddressType AddressType { get; set; }

        [StringLength(250)]
        public string Address1 { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string ZipCodePlus4 { get; set; }

        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string CellPhone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [Required] 
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [StringLength(10)]
        public string Ext { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTimeOffset? DateUpdated { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public int SupplierProfileId { get; set; }

        [ForeignKey("SupplierProfileId")]
        public SupplierProfile SupplierProfile { get; set; }
    }
}
