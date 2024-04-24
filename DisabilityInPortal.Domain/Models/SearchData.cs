using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Models
{
    public class SearchData
    {
        public int ApplicationId { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public int? FilterBy { get; set; }
        public int? Geographical { get; set; }
        public List<string> Naicscodes { get; set; }
        public List<string> Siccodes { get; set; }
        public List<string> Unspsccodes { get; set; }
        public List<int> Diversiylist { get; set; }
        public int? IndustryTypeValue { get; set; }
        public List<string> BizRefNames { get; set; }
        public decimal PreviousGrossIncomes { get; set; }
        public decimal LastPreviousGrossIncomes { get; set; }
        public decimal SecondLastPreviousGrossIncomes { get; set; }
        public int? EmployeeCount { get; set; }
        public List<WareHouseArea> WareHouseArea { get; set; }
        public List<int?> HeadQuarterCountry { get; set; }
        public List<int?> HeadQuarterState { get; set; }
        public List<string> HeadQuarterCity { get; set; }
        public List<string> HeadQuarterZip { get; set; }
        public List<string> HeadQuarterZip4 { get; set; }
        public List<int?> ContractReferenceCountry { get; set; }
        public List<int?> ContractReferenceState { get; set; }
        public List<string> ContractreferenceEmail { get; set; }
        public List<string> ContractreferenceCity { get; set; }
        public List<string> ContractreferenceZip { get; set; }
        public List<string> ContractreferenceZip4 { get; set; }
        public List<string> ContractReferneceProductOrService { get; set; }
    }
}
