using DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos
{
    public class SupplierProfileCertificationAgencyDto
    {
        public int SupplierProfileId { get; set; }
        public int CertificationAgencyId { get; set; }
        public int? SupplierProfileDocumentId { get; set; }
        public bool Checked { get; set; }
        public CertificationAgencyDto CertificationAgencyDto { get; set; }
    }
}
