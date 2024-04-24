using System.ComponentModel.DataAnnotations;


namespace DisabilityInPortal.Domain.Enums
{
    public enum IncomeType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Net Income")]
        NetIncome = 1,

        [Display(Name = "Gross Income")]
        GrossIncome = 2
    }
}
