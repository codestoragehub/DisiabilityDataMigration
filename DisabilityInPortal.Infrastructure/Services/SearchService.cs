using System;
using System.Collections.Generic;
using System.Linq;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Models;
using DisabilityInPortal.Infrastructure.Persistence;

namespace DisabilityInPortal.Infrastructure.Services;

public class SearchService : ISearchService
{
    private readonly DisabilityInPortalDbContext _dbContext;

    public SearchService(DisabilityInPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SearchQueryResult> SearchSupplierByParameterAsync(SearchRequest searchRequest)
    {
        var result = (from company in _dbContext.Companies
            join application in _dbContext.Applications on company.CompanyId equals application.CompanyId
            join user in _dbContext.ApplicationUsers on application.UserId equals user.Id into searchUser
            from user in searchUser.DefaultIfEmpty()
            select new SearchData
            {
                ApplicationId = application.ApplicationId,
                SupplierName = company.LegalBusinessName,
                FilterBy = (int)user.VeteranStatusType,
                Email = user.Email,
                HeadQuarterCountry = application.AddressList
                    .Where(x => x.AddressType == AddressType.HeadquartersInformation).Select(x => x.CountryId).ToList(),
                HeadQuarterState = application.AddressList
                    .Where(x => x.AddressType == AddressType.HeadquartersInformation).Select(x => x.StateId).ToList(),
                HeadQuarterCity = application.AddressList
                    .Where(x => x.AddressType == AddressType.HeadquartersInformation).Select(x => x.City).ToList(),
                HeadQuarterZip = application.AddressList
                    .Where(x => x.AddressType == AddressType.HeadquartersInformation).Select(x => x.ZipCode).ToList(),
                HeadQuarterZip4 = application.AddressList
                    .Where(x => x.AddressType == AddressType.HeadquartersInformation).Select(x => x.ZipCodePlus4)
                    .ToList(),
                Naicscodes = application.Capability.NaicsCodes.Select(c => c.Code).ToList(),
                Siccodes = application.Capability.SicCodes.Select(c => c.Code).ToList(),
                Unspsccodes = application.Capability.UnspscCodes.Select(c => c.Code).ToList(),
                Geographical = (int)application.Capability.GeographicalServiceArea,
                IndustryTypeValue = (int)company.IndustryType.GetValueOrDefault(),
                Diversiylist = application.DiversityList.Select(c => (int)c.DiversityType).ToList(),
                PreviousGrossIncomes = application.FinancialSizeInfo.Incomes
                    .Where(x => x.Year == DateTime.Now.Year - 1 &&
                                x.FinancialSizeInfo.ApplicationId == application.ApplicationId)
                    .Select(x => x.YearIncome).FirstOrDefault(),
                LastPreviousGrossIncomes = application.FinancialSizeInfo.Incomes
                    .Where(x => x.Year == DateTime.Now.Year - 2 &&
                                x.FinancialSizeInfo.ApplicationId == application.ApplicationId)
                    .Select(x => x.YearIncome).FirstOrDefault(),
                SecondLastPreviousGrossIncomes = application.FinancialSizeInfo.Incomes
                    .Where(x => x.Year == DateTime.Now.Year - 3 &&
                                x.FinancialSizeInfo.ApplicationId == application.ApplicationId)
                    .Select(x => x.YearIncome).FirstOrDefault(),
                EmployeeCount = application.FinancialSizeInfo.CurrentEmployeesNo,
                BizRefNames = application.ContractReferenceList.Select(x => x.CompanyOrOrganizationName).ToList(),
                ContractReferenceCountry = application.AddressList
                    .Where(x => x.AddressType == AddressType.ContractReference).Select(x => x.CountryId).ToList(),
                ContractReferenceState = application.AddressList
                    .Where(x => x.AddressType == AddressType.ContractReference).Select(x => x.StateId).ToList(),
                ContractreferenceCity = application.ContractReferenceList.Select(c => c.Address.City).ToList(),
                ContractreferenceZip = application.ContractReferenceList.Select(c => c.Address.ZipCode).ToList(),
                ContractreferenceZip4 = application.ContractReferenceList.Select(c => c.Address.ZipCodePlus4).ToList(),
                ContractReferneceProductOrService =
                    application.ContractReferenceList.Select(c => c.ProductOrService).ToList(),
                ContractreferenceEmail = application.ContractReferenceList.Select(c => c.Address.Email).ToList()
            }).ToList();

        if (Enum.IsDefined(typeof(SearchFieldType), searchRequest.SearchFieldType))
            if (!string.IsNullOrWhiteSpace(searchRequest.SearchText))
                switch (searchRequest.SearchFieldType)
                {
                    case SearchFieldType.SupplierName:
                        result = result.Where(x => x.SupplierName == searchRequest.SearchText).ToList();
                        break;
                    case SearchFieldType.Email:
                        result = result.Where(x => x.Email == searchRequest.SearchText).ToList();
                        break;
                    case SearchFieldType.State:
                        var states = from state in _dbContext.States
                            where state.Name == searchRequest.SearchText
                            select state.StateId;
                        result = result.Where(x => x.HeadQuarterState == states).ToList();
                        break;
                    case SearchFieldType.City:
                        result = result.Where(x => x.HeadQuarterCity.Contains(searchRequest.SearchText)).ToList();
                        break;
                    case SearchFieldType.NaicsCode:
                        result = result.Where(x => x.Naicscodes.Contains(searchRequest.SearchText)).ToList();
                        break;
                }

        if (Enum.IsDefined(typeof(VeteranStatusType), searchRequest.FilterBy))
            result = result.Where(x => x.FilterBy == (int)searchRequest.FilterBy).ToList();

        if (searchRequest.SupplierCountryId != 0)
            result = result.Where(x => x.HeadQuarterCountry.Contains(searchRequest.SupplierCountryId)).ToList();

        if (searchRequest.SupplierStateId != 0)
            result = result.Where(x => x.HeadQuarterState.Contains((char)searchRequest.SupplierStateId)).ToList();
        if (!string.IsNullOrEmpty(searchRequest.SupplierCity))
            result = result.Where(x => x.HeadQuarterCity.Contains(searchRequest.SupplierCity)).ToList();
        if (!string.IsNullOrEmpty(searchRequest.SupplierZipCode))
            result = result.Where(x => x.HeadQuarterZip.Contains(searchRequest.SupplierZipCode)).ToList();
        if (!string.IsNullOrEmpty(searchRequest.SupplierZipCode4))
            result = result.Where(x => x.HeadQuarterZip4.Contains(searchRequest.SupplierZipCode4)).ToList();

        if (!string.IsNullOrEmpty(searchRequest.NaicsCode))
            result = result.Where(x => x.Naicscodes.Contains(searchRequest.NaicsCode)).ToList();

        if (!string.IsNullOrEmpty(searchRequest.SicCodes))
            result = result.Where(x => x.Siccodes.Contains(searchRequest.SicCodes)).ToList();

        if (!string.IsNullOrEmpty(searchRequest.UnspscCodes))
            result = result.Where(x => x.Unspsccodes.Contains(searchRequest.UnspscCodes)).ToList();

        if (searchRequest.NumberOfEmployees != 0)
        {
            result = searchRequest.NumberOfEmployees switch
            {
                SearchEmployeesCountType.LessThan100 => result
                    .Where(x => x.EmployeeCount <= (int)searchRequest.NumberOfEmployees)
                    .ToList(),
                SearchEmployeesCountType.From101To500 => result.Where(x =>
                        x.EmployeeCount > (int)SearchEmployeesCountType.LessThan100 &&
                        x.EmployeeCount <= (int)searchRequest.NumberOfEmployees)
                    .ToList(),
                SearchEmployeesCountType.From501To1000 => result.Where(x =>
                        x.EmployeeCount > (int)SearchEmployeesCountType.From101To500 &&
                        x.EmployeeCount <= (int)searchRequest.NumberOfEmployees)
                    .ToList(),
                SearchEmployeesCountType.GreaterThan1001 => result.Where(x =>
                        x.EmployeeCount > (int)SearchEmployeesCountType.From501To1000 &&
                        x.EmployeeCount <= (int)searchRequest.NumberOfEmployees)
                    .ToList(),
                _ => result
            };
        }

        if (searchRequest.GrossIncomeLastYear != 0)
        {
            result = searchRequest.GrossIncomeLastYear switch
            {
                SearchGrossIncomeType.LessThen10000USD => result
                    .Where(x => x.PreviousGrossIncomes <= (decimal)searchRequest.GrossIncomeLastYear)
                    .ToList(),
                SearchGrossIncomeType.From10001To25000USD => result.Where(x =>
                        x.PreviousGrossIncomes > (decimal)SearchGrossIncomeType.LessThen10000USD &&
                        x.PreviousGrossIncomes <= (decimal)searchRequest.GrossIncomeLastYear)
                    .ToList(),
                SearchGrossIncomeType.From25001To50000USD => result.Where(x =>
                        x.PreviousGrossIncomes > (decimal)SearchGrossIncomeType.From10001To25000USD &&
                        x.PreviousGrossIncomes <= (decimal)searchRequest.GrossIncomeLastYear)
                    .ToList(),
                SearchGrossIncomeType.From50001To75000USD => result.Where(x =>
                        x.PreviousGrossIncomes > (decimal)SearchGrossIncomeType.From25001To50000USD &&
                        x.PreviousGrossIncomes <= (decimal)searchRequest.GrossIncomeLastYear)
                    .ToList(),
                SearchGrossIncomeType.GreaterThen75001USD => result.Where(x =>
                        x.PreviousGrossIncomes >= (decimal)SearchGrossIncomeType.GreaterThen75001USD)
                    .ToList(),
                _ => result
            };
        }

        if (searchRequest.GrossIncome2ndLastYear != 0)
        {
            result = searchRequest.GrossIncome2ndLastYear switch
            {
                SearchGrossIncomeType.LessThen10000USD => result.Where(x =>
                        x.LastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome2ndLastYear)
                    .ToList(),
                SearchGrossIncomeType.From10001To25000USD => result.Where(x =>
                        x.LastPreviousGrossIncomes > (decimal)SearchGrossIncomeType.LessThen10000USD &&
                        x.LastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome2ndLastYear)
                    .ToList(),
                SearchGrossIncomeType.From25001To50000USD => result.Where(x =>
                        x.LastPreviousGrossIncomes > (decimal)SearchGrossIncomeType.From10001To25000USD &&
                        x.LastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome2ndLastYear)
                    .ToList(),
                SearchGrossIncomeType.From50001To75000USD => result.Where(x =>
                        x.LastPreviousGrossIncomes > (decimal)SearchGrossIncomeType.From25001To50000USD &&
                        x.LastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome2ndLastYear)
                    .ToList(),
                SearchGrossIncomeType.GreaterThen75001USD => result.Where(x =>
                        x.LastPreviousGrossIncomes >= (decimal)SearchGrossIncomeType.GreaterThen75001USD)
                    .ToList(),
                _ => result
            };
        }

        if (searchRequest.GrossIncome3rdLastYear != 0)
        {
            result = searchRequest.GrossIncome3rdLastYear switch
            {
                SearchGrossIncomeType.LessThen10000USD => result.Where(x =>
                        x.SecondLastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome3rdLastYear)
                    .ToList(),
                SearchGrossIncomeType.From10001To25000USD => result.Where(x =>
                        x.SecondLastPreviousGrossIncomes > (decimal)SearchGrossIncomeType.LessThen10000USD &&
                        x.SecondLastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome3rdLastYear)
                    .ToList(),
                SearchGrossIncomeType.From25001To50000USD => result.Where(x =>
                        x.SecondLastPreviousGrossIncomes > (decimal)SearchGrossIncomeType.From10001To25000USD &&
                        x.SecondLastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome3rdLastYear)
                    .ToList(),
                SearchGrossIncomeType.From50001To75000USD => result.Where(x =>
                        x.SecondLastPreviousGrossIncomes > (decimal)SearchGrossIncomeType.From25001To50000USD &&
                        x.SecondLastPreviousGrossIncomes <= (decimal)searchRequest.GrossIncome3rdLastYear)
                    .ToList(),
                SearchGrossIncomeType.GreaterThen75001USD => result.Where(x =>
                        x.SecondLastPreviousGrossIncomes >= (decimal)SearchGrossIncomeType.GreaterThen75001USD)
                    .ToList(),
                _ => result
            };
        }

        if (searchRequest.WarehouseSqFootage != 0)
        {
            result = searchRequest.WarehouseSqFootage switch
            {
                SearchWarehouseSqFtType.LessThan1000 => result
                    .Where(x => x.WareHouseArea.Any(k => (int)searchRequest.WarehouseSqFootage <= k.Area))
                    .ToList(),
                SearchWarehouseSqFtType.From1001To5000 => result.Where(x => x.WareHouseArea.Any(k =>
                        k.Area > (int)SearchWarehouseSqFtType.LessThan1000 &&
                        k.Area <= (int)searchRequest.WarehouseSqFootage))
                    .ToList(),
                SearchWarehouseSqFtType.From5001To10000 => result.Where(x => x.WareHouseArea.Any(k =>
                        k.Area > (int)SearchWarehouseSqFtType.From1001To5000 &&
                        k.Area <= (int)searchRequest.WarehouseSqFootage))
                    .ToList(),
                SearchWarehouseSqFtType.GreaterThan10001 => result.Where(x => x.WareHouseArea.Any(k =>
                        k.Area > (int)SearchWarehouseSqFtType.From5001To10000 &&
                        k.Area <= (int)searchRequest.WarehouseSqFootage))
                    .ToList(),
                _ => result
            };
        }

        if (searchRequest.IndustryTypevalue != 0)
            result = result.Where(x => x.IndustryTypeValue == searchRequest.IndustryTypevalue).ToList();

        if (searchRequest.GeographicalServiceAreavalue != 0)
            result = result.Where(x => x.Geographical == searchRequest.GeographicalServiceAreavalue).ToList();

        if (searchRequest.DiversityTypeValue != 0)
            result = result.Where(x => x.Diversiylist.Contains(searchRequest.DiversityTypeValue)).ToList();

        if (!string.IsNullOrEmpty(searchRequest.CompanyOrganization))
            result = result.Where(x => x.BizRefNames.Contains(searchRequest.CompanyOrganization)).ToList();

        if (!string.IsNullOrEmpty(searchRequest.ContractReferenceEmail))
            result = result.Where(x => x.ContractreferenceEmail.Contains(searchRequest.ContractReferenceEmail))
                .ToList();
        if (!string.IsNullOrEmpty(searchRequest.ContractReferenceCity))
            result = result.Where(x => x.ContractreferenceCity.Contains(searchRequest.ContractReferenceCity)).ToList();
        if (!string.IsNullOrEmpty(searchRequest.ContractReferenceZip))
            result = result.Where(x => x.ContractreferenceZip.Contains(searchRequest.ContractReferenceZip)).ToList();
        if (!string.IsNullOrEmpty(searchRequest.ContractReferenceZip4))
            result = result.Where(x => x.ContractreferenceZip4.Contains(searchRequest.ContractReferenceZip4)).ToList();

        if (!string.IsNullOrEmpty(searchRequest.ContractReferneceProductOrService))
            result = result.Where(x =>
                x.ContractReferneceProductOrService.Contains(searchRequest.ContractReferneceProductOrService)).ToList();

        var result1 = (from x in result
            group x by new { x.ApplicationId, x.SupplierName, x.Email }
            into g
            select new SearchQueryResult
            {
                ApplicationId = g.Key.ApplicationId,
                SupplierName = g.Key.SupplierName,
                UserName = g.Key.Email
            }).AsQueryable().ToList();

        return result1;
    }
}