using DisabilityInPortal.Domain.Entities.Common;
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
    [Table("SupplierProfileDocuments", Schema = "sp")]
    public class SupplierProfileDocument : AuditBaseEntity
    {
        public int SupplierProfileDocumentId { get; set; }

        public DocumentType Type { get; set; }

        [Required]
        [StringLength(1024)]
        public string FileName { get; set; }
                
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int SupplierProfileId { get; set; }
        public SupplierProfile SupplierProfile { get; set; }
    }
}
