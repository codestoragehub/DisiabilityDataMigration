using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Identity;
using DisabilityInPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DisabilityInPortal.Infrastructure.Persistence;

public class DisabilityInPortalDbContext
    : IdentityDbContext<
        ApplicationUser, 
        ApplicationRole, 
        string, 
        IdentityUserClaim<string>, 
        ApplicationUserRole, 
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>, 
        IdentityUserToken<string>>, IDisabilityInPortalDbContext
{
    private readonly ICurrentUserService _authenticatedUser;

    private readonly IDateTimeService _dateTime;

    public DisabilityInPortalDbContext(DbContextOptions<DisabilityInPortalDbContext> options) : base(options)
    {
        _authenticatedUser = new DesignTimeCurrentUserService();
        _dateTime = new DateTimeService();
    }

    public DisabilityInPortalDbContext(DbContextOptions<DisabilityInPortalDbContext> options,
        IDateTimeService dateTime,
        ICurrentUserService authenticatedUser) : base(options)
    {
        _dateTime = dateTime;
        _authenticatedUser = authenticatedUser;
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Audit> AuditLogs { get; set; }
    public DbSet<WorkflowHistoryEvent> WorkflowHistoryEvents { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CertificationAgency> CertificationAgencies { get; set; }
    public DbSet<ApplicationCertificationAgency> ApplicationCertificationAgencies { get; set; }
    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<AddressDocument> AddressDocuments { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<TrustDetail> TrustDetails { get; set; }
    public DbSet<TransportationDetail> TransportationDetails { get; set; }
    public DbSet<Capability> Capabilities { get; set; }
    public DbSet<ManagementContribution> ManagementContributions { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<ManagementResponsibility> ManagementResponsibilities { get; set; }
    public DbSet<Diversity> Diversities { get; set; }
    public DbSet<DisabilityImpact> DisabilityImpacts { get; set; }
    public DbSet<ManagementAtOutsideFirm> ManagementAtOutsideFirms { get; set; }
    public DbSet<Affidavit> Affidavits { get; set; }
    public DbSet<AdditionalDocumentList> AdditionalDocumentLists { get; set; }
    public DbSet<AdditionalDocument> AdditionalDocuments { get; set; }
    public DbSet<AdditionalInformation> AdditionalInformations { get; set; }
    public DbSet<NaicsCode> NaicsCodes { get; set; }
    public DbSet<SicCode> SicCodes { get; set; }
    public DbSet<UkSicCode> UkSicCodes { get; set; }
    public DbSet<UnspscCode> UnspscCodes { get; set; }
    public DbSet<UnNumberCode> UnNumberCodes { get; set; }
    public DbSet<ContractReference> ContractReferences { get; set; }
    public DbSet<BankAndCreditReference> BankAndCreditReferences { get; set; }
    public DbSet<BusinessRelationship> BusinessRelationships { get; set; }
    public DbSet<FinancialSizeInfo> FinancialSizeInfos { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<ManagementChange> ManagementChanges { get; set; }
    public DbSet<ApplicationDecision> ApplicationDecisions { get; set; }
    public DbSet<SectionReview> SectionReviews { get; set; }
    public DbSet<SiteVisitReview> SiteVisitReviews { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<CompanyHistoryAndOwnership> CompanyHistoryAndOwnerships { get; set; }
    public DbSet<OperationAndControl> OperationAndControls { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<DisabilityImpactDocument> DisabilityImpactDocuments { get; set; }
    public DbSet<LegalStructure> LegalStructures { get; set; }
    public DbSet<LegalStructureDocument> LegalStructureDocuments { get; set; }
    public DbSet<ApplicationAssignee> ApplicationAssignees { get; set; }

    public DbSet<SupplierProfile> SupplierProfiles { get; set; }
    public DbSet<SupplierProfileAddress> SupplierProfileAddresses { get; set; }
    public DbSet<SupplierProfileCapability> SupplierProfileCapabilities { get; set; }
    public DbSet<SupplierProfileContractReference> SupplierProfileContractReferences { get; set; }
    public DbSet<SupplierProfileDocument> SupplierProfileDocuments { get; set; }
    public DbSet<SupplierProfileCertificationAgency> SupplierProfileCertificationAgencies { get; set; }
    public DbSet<SupplierProfileLegalStructure> SupplierProfileLegalStructures { get; set; }

    public IDbConnection Connection => Database.GetDbConnection();

    public bool HasChanges => ChangeTracker.HasChanges();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdatedAuditEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdatedAuditEntities();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChanges)
    {
        UpdatedAuditEntities();
        return base.SaveChanges(acceptAllChanges);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChanges, CancellationToken cancellationToken)
    {
        UpdatedAuditEntities();
        return await base.SaveChangesAsync(acceptAllChanges, cancellationToken);
    }

    internal static DisabilityInPortalDbContext CreateContext()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables()
            .Build()
            .GetConnectionString("ApplicationConnection");

        return new DisabilityInPortalDbContext(
            new DbContextOptionsBuilder<DisabilityInPortalDbContext>()
                .UseSqlServer(configuration)
                .Options);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.HasDefaultSchema("dbo");
        
        ConfigureIdentityTables(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(DisabilityInPortalDbContext).Assembly);

        foreach (var property in builder.Model.GetEntityTypes()
                     .SelectMany(x => x.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?))
                )
            property.SetColumnType("decimal(18,2)");
    }

    private static void ConfigureIdentityTables(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>(entity => { entity.ToTable("Users", "Identity"); });
        builder.Entity<ApplicationRole>(entity => { entity.ToTable("Roles", "Identity"); });
        builder.Entity<ApplicationUserRole>(entity => { entity.ToTable("UserRoles", "Identity"); });
        builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims", "Identity"); });
        builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins", "Identity"); });
        builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims", "Identity"); });
        builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens", "Identity"); });
    }

    private void UpdatedAuditEntities()
    {
        var modifiedEntities = ChangeTracker
            .Entries()
            .Where(x => x.Entity is IAuditBaseEntity && x.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in modifiedEntities)
        {
            var entity = (IAuditBaseEntity)entry.Entity;
            var now = _dateTime.UtcNow;
            if (entry.State == EntityState.Added)
            {
                entity.DateCreated = now;
                entity.CreatedBy = _authenticatedUser.UserId;
            }
            else
            {
                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                base.Entry(entity).Property(x => x.DateCreated).IsModified = false;
            }

            entity.DateUpdated = _dateTime.UtcNow;
            entity.UpdatedBy = _authenticatedUser.UserId;
        }
    }
}