using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("SupplierProfileLegalStructure", Schema = "sp")]
    public class SupplierProfileLegalStructure : AuditBaseEntity
    {
        [Key]
        public int SupplierProfileLegalStructureId { get; set; }
        public LegalStructureType LegalStructureType { get; set; }

        [StringLength(1024)]
        public string LegalStructureTypeOther { get; set; }
        public int SupplierProfileId { get; set; }

        [ForeignKey("SupplierProfileId")]
        public SupplierProfile SupplierProfile { get; set; }
    }
}
