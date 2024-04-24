using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum PartnershipDocumentType
    {
        [Display(Name = "Partnership agreements")]
        PartnershipAgreements = 1,

        [Display(Name = "Proof of capital investment by Disability partners")]
        ProofOfCapitalInvestment = 2,

        [Display(Name = "Limited partnership agreements")]
        LimitedPartnershipAgreements = 3,

        [Display(Name = "Profit sharing agreements")]
        ProfitSharingAgreements = 4,

        [Display(Name = "Form 1065 K-1s (for each owner), Form 1120 Schedule G, OR Form 1065 Schedule K-1 (for each owner) ")]
        Form1065K1s = 5,
    }
}
