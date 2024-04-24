using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;


namespace DisabilityInPortal.Domain.Entities
{
    [Table("Income")]
    public class Income
    {
        public int IncomeId { get; set; }        
        public int Year { get; set; }
        public decimal YearIncome { get; set; }
        public IncomeType IncomeType { get; set; }
        public int? ProfitLossStatementId { get; set; }
        public Document ProfitLossStatement { get; set; }
        public int? BalanceSheetId { get; set; }
        public Document BalanceSheet { get; set; }
        public int? SsdStatementId { get; set; }
        public Document SsdStatement { get; set; }
        public int? SsiStatementId { get; set; }
        public Document SsiStatement { get; set; }
        public int? FederalTaxReturnId { get; set; }
        public Document FederalTaxReturn { get; set; }
        public int? DocumentId { get; set; }
        public Document Document { get; set; }
        public int FinancialSizeInfoId { get; set; }
        public FinancialSizeInfo FinancialSizeInfo { get; set; }
    }
}
