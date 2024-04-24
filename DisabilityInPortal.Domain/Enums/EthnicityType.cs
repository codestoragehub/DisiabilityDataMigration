using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum EthnicityType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Asian")]
        Asian = 1,

        [Display(Name = "Black/African American")]
        BlackAfricanAmerican = 2,

        [Display(Name = "Hispanic")]
        Hispanic = 3,

        [Display(Name = "Native American/Alaska Native")]
        NativeAmericanAlaskaNative = 4,

        [Display(Name = "Native Hawaiian/Pacific Islander")]
        NativeHawaiianPacificIslander = 5,

        [Display(Name = "White, Non-Hispanic")]
        WhiteNonHispanic = 6,

        [Display(Name = "Other")]
        Other = 7,

        [Display(Name = "I prefer not to answer")]
        IPreferNotToAnswer = 8
    }
}
