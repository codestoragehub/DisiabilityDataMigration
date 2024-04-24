using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("FinancialSizeInfos")]
public class FinancialSizeInfo
{
    public FinancialSizeInfo()
    {
        Incomes = new List<Income>();
    }

    public int FinancialSizeInfoId { get; set; }

    [StringLength(1024)]
    public string ServicesProvided { get; set; }

    public IndustryType IndustryType { get; set; }

    [StringLength(1024)]
    public string IndustryTypeOther { get; set; }

    public int CurrentEmployeesNo { get; set; }
    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int? RecentItemizedPayrollId { get; set; }
    public Document RecentItemizedPayroll { get; set; }

    public List<Income> Incomes { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }

    [StringLength(1024)]
    public string PrimarySourceOfIncome { get; set; }
}