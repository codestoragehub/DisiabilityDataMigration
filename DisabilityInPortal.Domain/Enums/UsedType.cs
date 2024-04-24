using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum UsedType
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Applicable")]
        Applicable = 1,
        [Display(Name = "Not Applicable")]
        NotApplicable = 2
    }
}
