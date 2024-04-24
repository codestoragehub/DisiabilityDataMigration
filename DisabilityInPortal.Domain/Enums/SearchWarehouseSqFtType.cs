using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
	public enum SearchWarehouseSqFtType
	{
        [Display(Name = "0 - 1000")]
        LessThan1000 = 1000,

        [Display(Name = "1001 - 5000")]
        From1001To5000 = 5000,

        [Display(Name = "5001 - 10000")]
        From5001To10000 = 10000,

        [Display(Name = "Above 10000")]
        GreaterThan10001 = 10001,
    }
}
