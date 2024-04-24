using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Models
{
    public class SearchRequest
    {
        public string SearchText { get; set; }
        public SearchFieldType SearchFieldType { get; set; }
        public VeteranStatusType FilterBy { get; set; }

        public int SupplierCountryId { get; set; }
        public int SupplierStateId { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierZipCode { get; set; }
        public string SupplierZipCode4 { get; set; }

        public SearchGrossIncomeType GrossIncomeLastYear { get; set; }
        public SearchGrossIncomeType GrossIncome2ndLastYear { get; set; }
        public SearchGrossIncomeType GrossIncome3rdLastYear { get; set; }
        public SearchYearsExistenceType YearsInExistence { get; set; }
        public int YearsInExistencevalue { get; set; }
        public SearchEmployeesCountType NumberOfEmployees { get; set; }
        public int NumberOfEmployeesvalue { get; set; }
        public SearchWarehouseSqFtType WarehouseSqFootage { get; set; }
        public decimal BondingAmount { get; set; }
        public bool SecurityClearance { get; set; }
        public string NaicsCode { get; set; }
        public string SicCodes { get; set; }
        public string UnspscCodes { get; set; }
        public string ProductAndServiceText { get; set; }
        public IndustryType IndustryType { get; set; }
        public int IndustryTypevalue { get; set; }
        public int GeographicalServiceAreavalue { get; set; }
        public DiversityType DiversityType { get; set; }
        public int DiversityTypeValue { get; set; }
        public CerificationType CerificationType { get; set; }
        public int CerificationTypeValue { get; set; }
        public string CompanyOrganization { get; set; }
        public int ContractReferenceCountry { get; set; }
        public int ContractReferencestate { get; set; }
        public string ContractReferenceEmail { get; set; }
        public string ContractReferenceCity { get; set; }
        public string ContractReferenceZip { get; set; }
        public string ContractReferenceZip4 { get; set; }
        public string ContractReferneceProductOrService { get; set; }

    }
}
