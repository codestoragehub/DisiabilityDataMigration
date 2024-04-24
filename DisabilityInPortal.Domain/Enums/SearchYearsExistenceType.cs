using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum SearchYearsExistenceType
    {
        [Display(Name = "1 - 3 Years")]
        LessThan3Years = 5,

        [Display(Name = "3 - 10 Years")]
        From6To10Years = 10,

        [Display(Name = "11 - 20 Years")]
        From11To20Years = 20,

        [Display(Name = "21+ Years")]
        GreaterThan21Years = 21,      
    }
}
