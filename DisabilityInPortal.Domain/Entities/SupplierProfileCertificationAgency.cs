using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("SupplierProfileCertificationAgencies", Schema = "sp")]
    public class SupplierProfileCertificationAgency : AuditBaseEntity
    {
        public int SupplierProfileCertificationAgencyId { get; set; }
        public int SupplierProfileId { get; set; }
        public SupplierProfile SupplierProfile { get; set; }

        public int CertificationAgencyId { get; set; }
        public CertificationAgency CertificationAgency { get; set; }

        public int? SupplierProfileDocumentId { get; set; }

        [ForeignKey("SupplierProfileDocumentId")]
        public SupplierProfileDocument Document { get; set; }
       
    }
}
