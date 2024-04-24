using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.FinancialSizeInfo.Dtos
{
    public class IncomeDto
    {
        public int IncomeId { get; set; }
        public int Year { get; set; }
        public decimal YearIncome { get; set; }
        public IncomeType IncomeType { get; set; }
        public int? ProfitLossStatementId { get; set; }
        public int? BalanceSheetId { get; set; }
        public int? SsdStatementId { get; set; }
        public int? SsiStatementId { get; set; }
        public int? FederalTaxReturnId { get; set; }
        public int? DocumentId { get; set; }
        public int FinancialSizeInfoId { get; set; }
        public FinancialSizeInfoDto FinancialSizeInfo { get; set; }
    }
}
