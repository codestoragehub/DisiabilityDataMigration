using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
	public enum SearchGrossIncomeType
	{
        [Display(Name = "$0 - $10000")]
        LessThen10000USD = 10000,
        [Display(Name = "$10001 - $25000")]
        From10001To25000USD = 25000,
        [Display(Name = "$25001 - $50000")]
        From25001To50000USD = 50000,
        [Display(Name = "$50001 - $75000")]
        From50001To75000USD = 75000,
        [Display(Name = "Above $75000")]
        GreaterThen75001USD = 75001,
    }
}
