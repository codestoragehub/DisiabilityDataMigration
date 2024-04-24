using System.ComponentModel;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class DocumentDependentEntityUpdater : IDocumentDependentEntityUpdater
{
    private readonly IAdditionalDocumentRepository _additionalDocumentRepository;
    private readonly IAdditionalInformationRepository _additionalInformationRepository;
    private readonly IAddressDocumentsRepository _addressDocumentsRepository;
    private readonly IBankAndCreditReferenceRepository _bankAndCreditReferenceRepository;
    private readonly IBusinessRelationshipRepository _businessRelationshipsRepository;
    private readonly IApplicationCertificationAgencyRepository _certificationAgencyRepository;
    private readonly IContractReferenceRepository _contractReferenceRepository;
    private readonly IDisabilityImpactDocumentRepository _disabilityImpactDocumentRepository;
    private readonly IDiversityRepository _diversityRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IFacilityRepository _facilityRepository;
    private readonly IFinancialSizeRepository _financialSizeRepository;
    private readonly IIncomeRepository _incomeRepository;
    private readonly IManagementChangeAgreementRepository _managementChangeAgreementRepository;
    private readonly IManagementResponsibilityOwnerRepository _managementResponsibilityOwnerRepository;
    private readonly IOutsideFirmIndividualRepository _outsideFirmIndividualRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly ITransportationDetailRepository _transportationDetailRepository;
    private readonly ITrustDetailRepository _trustDetailRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public DocumentDependentEntityUpdater(
        ITrustDetailRepository trustDetailRepository,
        IApplicationCertificationAgencyRepository certificationAgencyRepository,
        IManagementResponsibilityOwnerRepository managementResponsibilityOwnerRepository,
        IAdditionalInformationRepository additionalInformationRepository,
        IBusinessRelationshipRepository businessRelationshipsRepository,
        IIncomeRepository incomeRepository,
        IFinancialSizeRepository financialSizeRepository,
        IDiversityRepository diversityRepository,
        IBankAndCreditReferenceRepository bankAndCreditReferenceRepository,
        IEquipmentRepository equipmentRepository,
        IVehicleRepository vehicleRepository,
        IFacilityRepository facilityRepository,
        IAdditionalDocumentRepository additionalDocumentRepository,
        IOutsideFirmIndividualRepository outsideFirmIndividualRepository,
        IManagementChangeAgreementRepository managementChangeAgreementRepository,
        IOwnerRepository ownerRepository,
        IAddressDocumentsRepository addressDocumentsRepository,
        IDisabilityImpactDocumentRepository disabilityImpactDocumentRepository,
        ITransportationDetailRepository transportationDetailRepository,
        IContractReferenceRepository contractReferenceRepository)
    {
        _trustDetailRepository = trustDetailRepository;
        _certificationAgencyRepository = certificationAgencyRepository;
        _managementResponsibilityOwnerRepository = managementResponsibilityOwnerRepository;
        _additionalInformationRepository = additionalInformationRepository;
        _businessRelationshipsRepository = businessRelationshipsRepository;
        _incomeRepository = incomeRepository;
        _financialSizeRepository = financialSizeRepository;
        _diversityRepository = diversityRepository;
        _bankAndCreditReferenceRepository = bankAndCreditReferenceRepository;
        _equipmentRepository = equipmentRepository;
        _vehicleRepository = vehicleRepository;
        _facilityRepository = facilityRepository;
        _additionalDocumentRepository = additionalDocumentRepository;
        _outsideFirmIndividualRepository = outsideFirmIndividualRepository;
        _managementChangeAgreementRepository = managementChangeAgreementRepository;
        _ownerRepository = ownerRepository;
        _addressDocumentsRepository = addressDocumentsRepository;
        _disabilityImpactDocumentRepository = disabilityImpactDocumentRepository;
        _transportationDetailRepository = transportationDetailRepository;
        _contractReferenceRepository = contractReferenceRepository;
    }

    public async Task UpdateDependentEntitiesAsync(Document document)
    {
        switch (document.Type)
        {
            case DocumentType.CertificationAgency:
            case DocumentType.VaVerificationLetter:
                await UpdateCertificationAgencyAsync(document.DocumentId);
                break;

            case DocumentType.ExecutedTrustDocumentation:
                await UpdateTrustDetailAsync(document);
                break;

            case DocumentType.SigningAuthority:
                await UpdateManagementResponsibilityAsync(document.DocumentId);
                break;

            case DocumentType.Lawsuit:
            case DocumentType.Bankruptcy:
            case DocumentType.CertificationDenial:
            case DocumentType.SiteVisitAccomodationRequirements:
                await UpdateAdditionalInformationAsync(document);
                break;

            case DocumentType.BusinessRelationshipDocument:
                await UpdateBusinessRelationshipAsync(document);
                break;

            case DocumentType.EmployeesList:
            case DocumentType.RecentItemizedPayRoll:
                await UpdateFinancialSizeAsync(document);
                break;

            case DocumentType.SsdStatement:
            case DocumentType.SsiStatement:
            case DocumentType.FederalTaxReturn:
                await UpdateIncomeAsync(document);
                break;

            case DocumentType.DiversityCertificate:
                await UpdateDiversityAsync(document);
                break;

            case DocumentType.BankAndCreditReference:
                await UpdateBankAndCreditReferenceAsync(document);
                break;

            case DocumentType.EquipmentPurchaseAgreement:
                await UpdateEquipmentAsync(document);
                break;

            case DocumentType.VehiclePurchaseAgreement:
                await UpdateVehicleAsync(document);
                break;

            case DocumentType.AdditionalDocument:
                await UpdateAdditionalDocumentAsync(document.DocumentId);
                break;

            case DocumentType.RentalPurchaseAgreement:
                await UpdateRentalPurchaseAgreementAsync(document);
                break;

            case DocumentType.W2Or1099Form:
                await UpdateW2Or1099FormAsync(document);
                break;

            case DocumentType.ManagementChange:
                await UpdateManagementChangeAgreementAsync(document);
                break;

            case DocumentType.Resume:
                await UpdateResumeAsync(document);
                break;

            case DocumentType.PictureId:
            case DocumentType.Passport:
                await UpdateAddressDocumentsAsync(document);
                break;

            case DocumentType.TransportationContract:
                await UpdateContractForTransportationDetailsAsync(document);
                break;

            case DocumentType.TransportationLease:
                await UpdateLeaseForTransportationDetailsAsync(document);
                break;

            case DocumentType.DisabilityImpact:
                await UpdateDisabilityImpactDocumentAsync(document);
                break;

            case DocumentType.LoanAgreement:
                await UpdateLoanAgreementDocumentAsync(document);
                break;

            case DocumentType.ContractReference:
                await UpdateContractReferenceDocumentAsync(document);
                break;

            default:
                return;
        }
    }

    private async Task UpdateContractForTransportationDetailsAsync(Document document)
    {
        var model = await _transportationDetailRepository.GetByApplicationIdAsync(document.ApplicationId);
        if (model == null)
            return;

        model.ContractDocumentId = null;
    }

    private async Task UpdateLeaseForTransportationDetailsAsync(Document document)
    {
        var model = await _transportationDetailRepository.GetByApplicationIdAsync(document.ApplicationId);
        if (model == null)
            return;

        model.LeaseDocumentId = null;
    }

    private async Task UpdateAdditionalInformationAsync(Document document)
    {
        var additionalInfo = await _additionalInformationRepository.GetByApplicationIdAsync(document.ApplicationId);
        if (additionalInfo == null)
            return;

        switch (document.Type)
        {
            case DocumentType.Lawsuit:
                additionalInfo.LawsuitDocumentId = null;
                return;

            case DocumentType.Bankruptcy:
                additionalInfo.BankruptcyDocumentId = null;
                return;

            case DocumentType.CertificationDenial:
                additionalInfo.CertificationDenialDocumentId = null;
                return;

            case DocumentType.SiteVisitAccomodationRequirements:
                additionalInfo.SiteVisitAccomodationRequirementsDocumentId = null;
                return;

            default:
                throw new InvalidEnumArgumentException(nameof(document.Type), (int)document.Type, typeof(DocumentType));
        }
    }

    private async Task UpdateAdditionalDocumentAsync(int documentId)
    {
        var additionalDocument = await _additionalDocumentRepository.GetByDocumentIdAsync(documentId);
        if (additionalDocument == null)
            return;

        additionalDocument.DocumentId = null;
    }

    private async Task UpdateManagementResponsibilityAsync(int documentId)
    {
        var managementResponsibility = await _managementResponsibilityOwnerRepository.GetByDocumentIdAsync(documentId);
        if (managementResponsibility == null)
            return;

        managementResponsibility.DocumentId = null;
    }

    private async Task UpdateCertificationAgencyAsync(int documentId)
    {
        var certificationAgency = await _certificationAgencyRepository.GetByDocumentIdAsync(documentId);
        if (certificationAgency == null)
            return;

        certificationAgency.DocumentId = null;
    }

    private async Task UpdateTrustDetailAsync(Document document)
    {
        var trustDetail = await _trustDetailRepository.GetByApplicationIdAsync(document.ApplicationId);
        if (trustDetail == null)
            return;

        trustDetail.DocumentId = null;
    }

    private async Task UpdateBusinessRelationshipAsync(Document document)
    {
        var businessRelationshipDetail =
            await _businessRelationshipsRepository.GetByDocumentIdAsync(document.DocumentId);
        if (businessRelationshipDetail == null)
            return;

        businessRelationshipDetail.DocumentId = null;
    }

    private async Task UpdateFinancialSizeAsync(Document document)
    {
        var finincialsize = await _financialSizeRepository.GetByApplicationIdAsync(document.ApplicationId);
        if (finincialsize == null)
            return;

        switch (document.Type)
        {
            case DocumentType.EmployeesList:
                finincialsize.DocumentId = null;
                return;

            case DocumentType.RecentItemizedPayRoll:
                finincialsize.RecentItemizedPayrollId = null;
                return;
        }
    }

    private async Task UpdateIncomeAsync(Document document)
    {
        var income = await _incomeRepository.GetByDocumentIdAsync(document.DocumentId);
        if (income == null)
            return;

        switch (document.Type)
        {
            case DocumentType.SsdStatement:
                income.SsdStatementId = null;
                return;

            case DocumentType.SsiStatement:
                income.SsiStatementId = null;
                return;

            case DocumentType.FederalTaxReturn:
                income.FederalTaxReturnId = null;
                return;
        }
    }

    private async Task UpdateDiversityAsync(Document document)
    {
        var diversityDetail = await _diversityRepository.GetByDocumentIdAsync(document.DocumentId);
        if (diversityDetail == null)
            return;

        diversityDetail.DocumentId = null;
    }

    private async Task UpdateBankAndCreditReferenceAsync(Document document)
    {
        var bankAndCreditReferenceDetail =
            await _bankAndCreditReferenceRepository.GetByDocumentIdAsync(document.DocumentId);
        if (bankAndCreditReferenceDetail == null)
            return;

        bankAndCreditReferenceDetail.DocumentId = null;
    }

    private async Task UpdateEquipmentAsync(Document document)
    {
        var equipmentDetail = await _equipmentRepository.GetByDocumentIdAsync(document.DocumentId);
        if (equipmentDetail == null)
            return;

        equipmentDetail.DocumentId = null;
    }

    private async Task UpdateVehicleAsync(Document document)
    {
        var vehicleDetail = await _vehicleRepository.GetByDocumentIdAsync(document.DocumentId);
        if (vehicleDetail == null)
            return;

        vehicleDetail.DocumentId = null;
    }

    private async Task UpdateRentalPurchaseAgreementAsync(Document document)
    {
        var facility = await _facilityRepository.GetByDocumentIdAsync(document.DocumentId);
        if (facility == null)
            return;

        facility.DocumentId = null;
    }

    private async Task UpdateW2Or1099FormAsync(Document document)
    {
        var outsideFirmIndividual = await _outsideFirmIndividualRepository.GetByDocumentIdAsync(document.DocumentId);
        if (outsideFirmIndividual == null)
            return;

        outsideFirmIndividual.DocumentId = null;
    }

    private async Task UpdateManagementChangeAgreementAsync(Document document)
    {
        var managementChangeAgreement =
            await _managementChangeAgreementRepository.GetByDocumentIdAsync(document.DocumentId);

        if (managementChangeAgreement == null)
            return;

        managementChangeAgreement.DocumentId = null;
    }

    private async Task UpdateResumeAsync(Document document)
    {
        var owner = await _ownerRepository.GetByDocumentIdAsync(document.DocumentId);
        if (owner == null)
            return;

        owner.DocumentId = null;
    }

    private async Task UpdateAddressDocumentsAsync(Document document)
    {
        var addressDocuments = await _addressDocumentsRepository.GetByDocumentIdAsync(document.DocumentId);
        if (addressDocuments == null)
            return;

        await _addressDocumentsRepository.DeleteAsync(addressDocuments);
    }

    private async Task UpdateDisabilityImpactDocumentAsync(Document document)
    {
        var disabilityImpactDocument =
            await _disabilityImpactDocumentRepository.GetDisabilityImpactDocumentByDocumentIdAsync(document.DocumentId);
        if (disabilityImpactDocument == null)
            return;

        disabilityImpactDocument.DocumentId = null;
    }

    private async Task UpdateLoanAgreementDocumentAsync(Document document)
    {
        var bankAndCreditReference =
            await _bankAndCreditReferenceRepository.GetByLoanAgreementDocumentIdAsync(document.DocumentId);

        if (bankAndCreditReference == null)
            return;

        bankAndCreditReference.LoanAgreementDocumentId = null;
    }

    private async Task UpdateContractReferenceDocumentAsync(Document document)
    {
        var contractReference = await _contractReferenceRepository.GetByDocumentIdAsync(document.DocumentId);
        if (contractReference == null)
            return;

        contractReference.DocumentId = null;
    }
}