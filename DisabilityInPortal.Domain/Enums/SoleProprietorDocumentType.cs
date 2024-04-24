using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum SoleProprietorDocumentType
    {
        [Display(Name = "Form 1040 Schedule C")]
        Form1040ScheduleC = 1,

        [Display(Name = "Applicable operating business license and/or permits")]
        ApplicableOperatingBusiness = 2,

        [Display(Name = "Assumed name documents (if applicable)")]
        AssumedNameDocuments = 3,
    }
}
