using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.Diversities.Queries.GetDiversityById
{
    public class DiversityDto
    {
        public int? DiversityId { get; set; }
        public DiversityType DiversityType { get; set; }
        public string CertifyingOrganization { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public string CertificationNumber { get; set; }
        public string DiversityTypeOther { get; set; }
        public int? DocumentId { get; set; }
        public int ApplicationId { get; set; }
    }
}
