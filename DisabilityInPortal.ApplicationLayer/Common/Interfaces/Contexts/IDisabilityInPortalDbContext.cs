using System.Data;
using System.Threading;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;

public interface IDisabilityInPortalDbContext
{
    IDbConnection Connection { get; }
    bool HasChanges { get; }

    DbSet<ApplicationUser> ApplicationUsers { get; set; }
    DbSet<Audit> AuditLogs { get; set; }
    DbSet<WorkflowHistoryEvent> WorkflowHistoryEvents { get; set; }
    DbSet<Application> Applications { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<Document> Documents { get; set; }
    DbSet<State> States { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Address> Addresses { get; set; }
    DbSet<CertificationAgency> CertificationAgencies { get; set; }
    DbSet<ApplicationCertificationAgency> ApplicationCertificationAgencies { get; set; }
    DbSet<RealEstate> RealEstates { get; set; }
    DbSet<AddressDocument> AddressDocuments { get; set; }
    DbSet<Contractor> Contractors { get; set; }
    DbSet<Equipment> Equipments { get; set; }
    DbSet<Vehicle> Vehicles { get; set; }
    DbSet<TrustDetail> TrustDetails { get; set; }
    DbSet<TransportationDetail> TransportationDetails { get; set; }
    DbSet<AdditionalInformation> AdditionalInformations { get; set; }
    DbSet<Affidavit> Affidavits { get; set; }
    DbSet<Capability> Capabilities { get; set; }
    DbSet<ManagementContribution> ManagementContributions { get; set; }
    DbSet<Owner> Owners { get; set; }
    DbSet<ManagementResponsibility> ManagementResponsibilities { get; set; }
    DbSet<Diversity> Diversities { get; set; }
    DbSet<DisabilityImpact> DisabilityImpacts { get; set; }
    DbSet<ManagementAtOutsideFirm> ManagementAtOutsideFirms { get; set; }
    DbSet<AdditionalDocumentList> AdditionalDocumentLists { get; set; }
    DbSet<AdditionalDocument> AdditionalDocuments { get; set; }
    DbSet<NaicsCode> NaicsCodes { get; set; }
    DbSet<SicCode> SicCodes { get; set; }
    DbSet<UkSicCode> UkSicCodes { get; set; }
    DbSet<UnspscCode> UnspscCodes { get; set; }
    DbSet<UnNumberCode> UnNumberCodes { get; set; }
    DbSet<ContractReference> ContractReferences { get; set; }
    DbSet<BankAndCreditReference> BankAndCreditReferences { get; set; }
    DbSet<BusinessRelationship> BusinessRelationships { get; set; }
    DbSet<FinancialSizeInfo> FinancialSizeInfos { get; set; }
    DbSet<Income> Incomes { get; set; }
    DbSet<ManagementChange> ManagementChanges { get; set; }
    DbSet<ApplicationDecision> ApplicationDecisions { get; set; }
    DbSet<SiteVisitReview> SiteVisitReviews { get; set; }
    DbSet<PaymentDetail> PaymentDetails { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    DbSet<Payment> Payments { get; set; }
    DbSet<Office> Offices { get; set; }
    DbSet<CompanyHistoryAndOwnership> CompanyHistoryAndOwnerships { get; set; }
    DbSet<OperationAndControl> OperationAndControls { get; set; }
    DbSet<Manager> Managers { get; set; }
    DbSet<DisabilityImpactDocument> DisabilityImpactDocuments { get; set; }
    DbSet<LegalStructure> LegalStructures { get; set; }
    DbSet<LegalStructureDocument> LegalStructureDocuments { get; set; }
    DbSet<ApplicationAssignee> ApplicationAssignees { get; set; }
    DbSet<SupplierProfile> SupplierProfiles { get; set; }
    DbSet<SupplierProfileAddress> SupplierProfileAddresses { get; set; }
    DbSet<SupplierProfileCapability> SupplierProfileCapabilities { get; set; }
    DbSet<SupplierProfileContractReference> SupplierProfileContractReferences { get; set; }
    DbSet<SupplierProfileDocument> SupplierProfileDocuments { get; set; }
    DbSet<SupplierProfileCertificationAgency> SupplierProfileCertificationAgencies { get; set; }
    DbSet<SupplierProfileLegalStructure> SupplierProfileLegalStructures { get; set; }
    EntityEntry Entry(object entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}