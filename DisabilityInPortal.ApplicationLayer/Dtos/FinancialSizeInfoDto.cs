
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Features.FinancialSizeInfo.Dtos
{
    public class FinancialSizeInfoDto
    {
        public int FinancialSizeInfoId { get; set; }        
        public string ServicesProvided { get; set; }
        public int CurrentEmployeesNo { get; set; }
        public string PrimarySourceOfIncome { get; set; }
        public int? RecentItemizedPayrollId { get; set; }
        public int? DocumentId { get; set; }        
        public List<IncomeDto> Incomes { get; set; }
        public int ApplicationId { get; set; }
      
    }
}
