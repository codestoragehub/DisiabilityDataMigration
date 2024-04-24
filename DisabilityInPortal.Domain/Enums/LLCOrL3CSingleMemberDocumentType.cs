using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum LLCOrL3CSingleMemberDocumentType
    {
        [Display(Name = "Articles of organization")]
        ArticlesOfOrganization = 1,

        [Display(Name = "Certificate of organization (for businesses in states which issue certificates)")]
        CertificateOfOrganization = 2,

        [Display(Name = "LLC regulations/operating agreement")]
        LLCRegulationsOperatingAgreement = 3,

        [Display(Name = "Form 1065 Schedule C, Form 1120 Schedule G, OR 1120s Schedule K-1")]
        Form1065ScheduleC = 4,
    }
}
