using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum SearchEmployeesCountType
    {
        [Display(Name = "0 - 100")]
        LessThan100 = 100,

        [Display(Name = "101 - 500")]
        From101To500 = 500,
        
        [Display(Name = "501 - 1000")]
        From501To1000 = 1000,
        
        [Display(Name = "Above 1000")]
        GreaterThan1001 = 1001,
    }
}
