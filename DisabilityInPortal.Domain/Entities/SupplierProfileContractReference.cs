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
    [Table("SupplierProfileContractReferences", Schema = "sp")]
    public class SupplierProfileContractReference
    {
        public int SupplierProfileContractReferenceId { get; set; }

        [StringLength(1024)]
        public string CompanyOrOrganizationName { get; set; }

        public int? AddressId { get; set; }
        public SupplierProfileAddress Address { get; set; }

        [StringLength(1024)]
        public string BuyerOrRepresentative { get; set; }

        [StringLength(1024)]
        public string ProductOrService { get; set; }
        public decimal DollarValue { get; set; }

        public int? SupplierProfileDocumentId { get; set; }
        public SupplierProfileDocument Document { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int SupplierProfileId { get; set; }
        [ForeignKey("SupplierProfileId")]
        public SupplierProfile SupplierProfile { get; set; }

    }
}
