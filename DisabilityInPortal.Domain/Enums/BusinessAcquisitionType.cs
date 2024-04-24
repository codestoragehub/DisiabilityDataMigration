using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum BusinessAcquisitionType
    {
        [Display(Name = "Started")]
        Started = 1,
        [Display(Name = "Purchased")]
        Purchased = 2,
        [Display(Name = "Inherited")]
        Inherited = 3,
        [Display(Name = "Gifted")]
        Gifted = 4,
    }
}
