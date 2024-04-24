using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum LLCOrL3CMultiMemberDocumentType
    {
        [Display(Name = "Articles of organization")]
        ArticlesOfOrganization = 1,

        [Display(Name = "Certificate of organization (for businesses in states which issue certificates)")]
        CertificateOfOrganization = 2,

        [Display(Name = "LLC regulations/operating agreement")]
        LLCRegulationsOperatingAgreement = 3,

        [Display(Name = "Form 1065 K-1s (for each owner), Form 1120 Schedule G, OR Form 1065 Schedule K-1 (for each owner) ")]
        Form1065ScheduleC = 4,
    }
}
