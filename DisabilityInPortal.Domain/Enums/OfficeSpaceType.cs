using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum OfficeSpaceType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Owned")]
        Owned = 1,

        [Display(Name = "Leased")]
        Leased = 2,

        [Display(Name = "Other")]
        Other = 3
    }
}
