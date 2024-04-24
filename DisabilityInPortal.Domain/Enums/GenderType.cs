using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum GenderType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Male")]
        Male = 1,

        [Display(Name = "Female")]
        Female = 2,

        [Display(Name = "Other")]
        Other = 3,

        [Display(Name = "I prefer not to answer")]
        IPreferNotToAnswer = 4,
    }
}
