using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("Diversities")]
    public class Diversity : AuditBaseEntity
    {
        public int DiversityId { get; set; }
        public DiversityType DiversityType { get; set; }

        [StringLength(256)]
        public string CertifyingOrganization { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        [StringLength(128)]
        public string CertificationNumber { get; set; }

        [StringLength(256)]
        public string DiversityTypeOther { get; set; }        
        public int? DocumentId { get; set; }
        public Document Document { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
