using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum BankAccountType
    {
        [Display(Name = "Checking")]
        Checking = 1,

        [Display(Name = "Savings")]
        Savings = 2,

        [Display(Name = "Money Market")]
        MoneyMarket = 3,

        [Display(Name = "Certificates of Deposit")]
        CD = 4,

        [Display(Name = "Brokerage")]
        Brokerage=5,

        [Display(Name = "Individual Retirement Account")]
        IRA = 6
    }
}
