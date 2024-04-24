using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos;

namespace DisabilityInPortal.ApplicationLayer.Common.Services
{
    public class SupplierProfileService : ISupplierProfileService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationService _applicationService;
        private readonly ISupplierProfileCapabilityService _supplierProfileCapabilityService;
        private readonly IDocumentFileService _documentFileService;
        private readonly IDocumentRepository _documentRepository;
        private readonly ISupplierProfileRepository _supplierProfileRepository;
        private readonly ISupplierProfileDocumentRepository _supplierProfileDocumentRepository;
        private readonly ISupplierProfileAddressRepository _supplierProfileAddressRepository;
        private readonly ILogger<SupplierProfileService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierProfileService(
            IApplicationService applicationService,
            ISupplierProfileCapabilityService supplierProfileCapabilityService,
            IApplicationRepository applicationRepository,
            IDocumentFileService documentFileService,
            IDocumentRepository documentRepository,
            ISupplierProfileRepository supplierProfileRepository,
            ISupplierProfileDocumentRepository supplierProfileDocumentRepository,
            ISupplierProfileAddressRepository supplierProfileAddressRepository,
            IUnitOfWork unitOfWork,
            ILogger<SupplierProfileService> logger)
        {
            _applicationService = applicationService;
            _supplierProfileCapabilityService = supplierProfileCapabilityService;
            _applicationRepository = applicationRepository;
            _documentFileService = documentFileService;
            _documentRepository = documentRepository;
            _supplierProfileRepository = supplierProfileRepository;
            _supplierProfileDocumentRepository = supplierProfileDocumentRepository;
            _supplierProfileAddressRepository = supplierProfileAddressRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> IsSupplierProfileExistByUserIdAsync(string userId)
        {
            return await _supplierProfileRepository.ExistsByUserIdAsync(userId);
        }

        public async Task<bool> IsSupplierProfileExistByApplicationIdAsync(int applicationId)
        {
            var applicationUser = await _applicationRepository.GetApplicationUserAsync(applicationId);
            return await _supplierProfileRepository.ExistsByUserIdAsync(applicationUser.Id);
        }

        public async Task<SupplierProfile> CreateSupplierProfileAsync(int applicationId)
        {
            var existingApplication = await _applicationRepository.GetApplicationByIdAllSubPropertiesAsync(applicationId);

            return await UtiliseNewSupplierProfileAsync(existingApplication);
        }

        private static void UtiliseAuditBase(IAuditBaseEntity auditBaseEntity)
        {
            auditBaseEntity.DateCreated = DateTimeOffset.UtcNow;
            auditBaseEntity.DateUpdated = null;
            auditBaseEntity.UpdatedBy = null;
        }
        private async Task<SupplierProfile> UtiliseNewSupplierProfileAsync(Application existingApplication)
        {
            var newSupplierProfile = new SupplierProfile
            {
                UserId = existingApplication.UserId,
                CreatedBy = existingApplication.CreatedBy,
                HowDidYouHearAboutUs = existingApplication.HowDidYouHearAboutUs,
                LegalBusinessName = existingApplication.Company.LegalBusinessName,
                DoingBusinessAs = existingApplication.Company.DoingBusinessAs,
                FormerCompanyNames = existingApplication.Company.FormerCompanyNames,
                CompanyWebsiteAddress = existingApplication.Company.CompanyWebsiteAddress,
                TaxIdType = existingApplication.Company.TaxIdType,
                FederalTaxId = existingApplication.Company.FederalTaxId,
                StateId = existingApplication.Company.StateId,
                CountryId = existingApplication.Company.CountryId,
                IsFranchise = existingApplication.Company.IsFranchise,
                NetIncome = (decimal)(existingApplication.FinancialSizeInfo?.Incomes
                   .Where(x => x.IncomeType == IncomeType.NetIncome
                             && x.FinancialSizeInfo.ApplicationId == existingApplication.ApplicationId)
                   .Select(x => x.YearIncome).FirstOrDefault()),
                GrossIncomeLastYear = (decimal)(existingApplication.FinancialSizeInfo?.Incomes
                   .Where(x => x.Year == DateTime.Now.Year - 1 && x.IncomeType == IncomeType.GrossIncome
                             && x.FinancialSizeInfo.ApplicationId == existingApplication.ApplicationId)
                   .Select(x => x.YearIncome).FirstOrDefault()),
                GrossIncome2ndLastYear = (decimal)(existingApplication.FinancialSizeInfo?.Incomes
                   .Where(x => x.Year == DateTime.Now.Year - 2 && x.IncomeType == IncomeType.GrossIncome
                             && x.FinancialSizeInfo.ApplicationId == existingApplication.ApplicationId)
                   .Select(x => x.YearIncome).FirstOrDefault()),
                GrossIncome3rdLastYear = (decimal)(existingApplication.FinancialSizeInfo?.Incomes
                   .Where(x => x.Year == DateTime.Now.Year - 3 && x.IncomeType == IncomeType.GrossIncome
                             && x.FinancialSizeInfo.ApplicationId == existingApplication.ApplicationId)
                   .Select(x => x.YearIncome).FirstOrDefault()),
                NumberOfEmployees = (int)(existingApplication.FinancialSizeInfo?.CurrentEmployeesNo),
                IndustryType = (IndustryType)existingApplication.Company.IndustryType,
                IndustryTypeOther = existingApplication.Company.IndustryTypeOther,
                ContractorLicenseNumber = existingApplication.Company.Contractor.LicenseNumber,
                ContractorTradeSpecialty = existingApplication.Company.Contractor.TradeSpecialty,
            };

            await _supplierProfileRepository.InsertAsync(newSupplierProfile);
            await _unitOfWork.Commit();

            try
            {
                UtiliseAddressList(existingApplication, newSupplierProfile);
                await UtiliseContractReferenceListAsync(existingApplication, newSupplierProfile);
                await UtiliseLegalStructureListAsync(existingApplication, newSupplierProfile);
                await UtiliseCapabilityAsync(existingApplication, newSupplierProfile);
                await UtiliseSupplierProfileCertificationAgenciesAsync(existingApplication, newSupplierProfile);
                await _supplierProfileRepository.UpdateAsync(newSupplierProfile);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "");
                await _supplierProfileRepository.DeleteAsync(newSupplierProfile);

                return null;
            }
            finally
            {
                await _unitOfWork.Commit();
            }

            return newSupplierProfile;
        }

        private async Task<SupplierProfileDocument> UtiliseDocumentAsync(int? documentId, SupplierProfile newSupplierProfile)
        {
            if (!documentId.HasValue)
                return null;

            try
            {
                var existingDocument = await _documentRepository.GetByIdAsync(documentId.Value);

                var newDocument = new SupplierProfileDocument
                {
                    SupplierProfileId = newSupplierProfile.SupplierProfileId,
                    Type = existingDocument.Type,
                    ApplicationUser = existingDocument.ApplicationUser,
                    CreatedBy = existingDocument.CreatedBy,
                    FileName = existingDocument.FileName,
                    UserId = existingDocument.UserId
                };

                await _supplierProfileDocumentRepository.InsertAsync(newDocument);
                await _unitOfWork.Commit();

                await _documentFileService.TransferDocumentAzureBlobToSupplierDocumentAzureBlobAsync(existingDocument, newDocument);

                return newDocument;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<SupplierProfileAddress> AddAddressAsync(Address address, SupplierProfile newSupplierProfile)
        {
            try
            {
                UtiliseAuditBase(address);
                var newSupplierAddress = new SupplierProfileAddress()
                {
                    Name = address.Name,
                    Address1 = address.Address1,
                    Title = address.Title,
                    AddressType = address.AddressType,
                    Email = address.Email,
                    Phone = address.Phone,
                    CellPhone = address.CellPhone,
                    ZipCode = address.ZipCode,
                    ZipCodePlus4 = address.ZipCodePlus4,
                    City = address.City,
                    StateId = address.StateId,
                    CountryId = address.CountryId,
                    Fax = address.Fax,
                    Ext = address.Ext,
                    SupplierProfileId = newSupplierProfile.SupplierProfileId,
                    UserId = newSupplierProfile.UserId
                };

                await _supplierProfileAddressRepository.InsertAsync(newSupplierAddress);
                await _unitOfWork.Commit();

                return newSupplierAddress;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void UtiliseAddress(Address address, SupplierProfile newSupplierProfile)
        {
            UtiliseAuditBase(address);
            var newSupplierAddress = new SupplierProfileAddress()
            {
                Name = address.Name,
                Address1 = address.Address1,
                Title = address.Title,
                AddressType = address.AddressType,
                Email = address.Email,
                Phone = address.Phone,
                CellPhone = address.CellPhone,
                ZipCode = address.ZipCode,
                ZipCodePlus4 = address.ZipCodePlus4,
                City = address.City,
                StateId = address.StateId,
                CountryId = address.CountryId,
                Fax = address.Fax,
                Ext = address.Ext,
                SupplierProfileId = newSupplierProfile.SupplierProfileId,
                UserId = newSupplierProfile.UserId
            };
            newSupplierProfile.AddressList.Add(newSupplierAddress);
        }

        private static void UtiliseAddressList(Application existingApplication, SupplierProfile supplierProfile)
        {

            var applicationAddressTypes = new[]
            {
            AddressType.CompanyContact,
            AddressType.HeadquartersInformation,
            AddressType.MailingAddress,
            AddressType.PrimaryOwnerContact,
        };

            var addresses = existingApplication.AddressList.Where(a => applicationAddressTypes.Contains(a.AddressType));
            foreach (var address in addresses)
                UtiliseAddress(address, supplierProfile);
        }

        private async Task UtiliseContractReferenceListAsync(Application existingApplication, SupplierProfile newSupplierProfile)
        {
            var sContractReferenceList = new List<SupplierProfileContractReference>();
            foreach (var item in existingApplication.ContractReferenceList)
            {
                var address = await AddAddressAsync(item.Address, newSupplierProfile);
                var supplierProfileContractReference = new SupplierProfileContractReference()
                {
                    CompanyOrOrganizationName = item.CompanyOrOrganizationName,
                    BuyerOrRepresentative = item.BuyerOrRepresentative,
                    ProductOrService = item.ProductOrService,
                    DollarValue = item.DollarValue,
                    SupplierProfileId = newSupplierProfile.SupplierProfileId,
                    UserId = newSupplierProfile.UserId,
                    Address = address,
                    AddressId = address.AddressId,
                };
             //   var document = await UtiliseDocumentAsync(item.DocumentId, newSupplierProfile);
                sContractReferenceList.Add(supplierProfileContractReference);
            }

            newSupplierProfile.ContractReferenceList = sContractReferenceList;
        }

        private static async Task UtiliseLegalStructureListAsync(Application existingApplication, SupplierProfile newSupplierProfile)
        {
            var slegalStructureList = new List<SupplierProfileLegalStructure>();
            foreach (var legalStructure in existingApplication.Company.LegalStructureList)
            {
                var supplierProfileLegalStructure = new SupplierProfileLegalStructure()
                {
                    LegalStructureType = legalStructure.LegalStructureType,
                    LegalStructureTypeOther = legalStructure.LegalStructureTypeOther,
                    SupplierProfileId = newSupplierProfile.SupplierProfileId,
                    SupplierProfile = newSupplierProfile
                };
                slegalStructureList.Add(supplierProfileLegalStructure);
            }
            newSupplierProfile.LegalStructureList = slegalStructureList;
        }

        private async Task UtiliseCapabilityAsync(Application existingApplication, SupplierProfile newSupplierProfile)
        {
            IList<string> GetStringCodes<T>(IEnumerable<T> codes) where T : ICode, new()
            {
                return codes.Select(c => c.Code).ToList();
            }

            await _supplierProfileCapabilityService.UpdateNaicsCodesAsync(
                newSupplierProfile,
                GetStringCodes(existingApplication.Capability.NaicsCodes));

            await _supplierProfileCapabilityService.UpdateSicCodesAsync(
                newSupplierProfile,
                GetStringCodes(existingApplication.Capability.SicCodes));

            await _supplierProfileCapabilityService.UpdateUnspscCodesAsync(
                newSupplierProfile,
                GetStringCodes(existingApplication.Capability.UnspscCodes));

            await _supplierProfileCapabilityService.UpdateUkSicCodesAsync(
                newSupplierProfile,
                GetStringCodes(existingApplication.Capability.UkSicCodes));

            await _supplierProfileCapabilityService.UpdateUnNumberCodesAsync(
                newSupplierProfile,
                GetStringCodes(existingApplication.Capability.UnNumberCodes));

            newSupplierProfile.ProfileCapability.GeographicalServiceArea = existingApplication.Capability.GeographicalServiceArea;
            newSupplierProfile.ProfileCapability.ProductServiceDescription = existingApplication.Capability.ProductServiceDescription;
        }

        //private async Task UtiliseCapabilityListAsync(Application existingApplication, SupplierProfile newSupplierProfile)
        //{
        //    //var supplierProfileCapability = new SupplierProfileCapability()
        //    //{
        //    //    ProductServiceDescription = existingApplication.Capability.ProductServiceDescription,
        //    //    GeographicalServiceArea = existingApplication.Capability.GeographicalServiceArea,
        //    //    NaicsCodes = existingApplication.Capability.NaicsCodes,
        //    //    SicCodes = existingApplication.Capability.SicCodes,
        //    //    UkSicCodes = existingApplication.Capability.UkSicCodes,
        //    //    UnspscCodes = existingApplication.Capability.UnspscCodes,
        //    //    UnNumberCodes = existingApplication.Capability.UnNumberCodes,
        //    //    SupplierProfileId = newSupplierProfile.SupplierProfileId,
        //    //    UserId = newSupplierProfile.UserId,
        //    //};
        //    //newSupplierProfile.ProfileCapability = supplierProfileCapability;
        //}

        private async Task UtiliseSupplierProfileCertificationAgenciesAsync(Application existingApplication, SupplierProfile newSupplierProfile)
        {

            var sCertificationAgencyList = new List<SupplierProfileCertificationAgency>();
            foreach (var certificationAgency in existingApplication.ApplicationCertificationAgencies)
            {
                var supplierProfilecertificationAgency = new SupplierProfileCertificationAgency()
                {
                    CertificationAgencyId = certificationAgency.CertificationAgencyId,
                    SupplierProfileId = newSupplierProfile.SupplierProfileId,
                    SupplierProfile = newSupplierProfile
                };

                
                if(certificationAgency.DocumentId != null)
                {
                    var document = await UtiliseDocumentAsync(certificationAgency.DocumentId, newSupplierProfile);
                    supplierProfilecertificationAgency.Document = document;
                    supplierProfilecertificationAgency.SupplierProfileDocumentId = document.SupplierProfileDocumentId;
                }
                sCertificationAgencyList.Add(supplierProfilecertificationAgency);
            }
            newSupplierProfile.CertificationAgencies = sCertificationAgencyList;
           
        }

    }
}
