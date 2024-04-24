using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly IRepositoryAsync<Application> _repository;

    public ApplicationRepository(IRepositoryAsync<Application> repository)
    {
        _repository = repository;
    }

    private IQueryable<Application> Applications => _repository.Entities;

    public async Task DeleteAsync(Application application)
    {
        await _repository.DeleteAsync(application);
    }

    public async Task<Application> GetApplicationByUserIdAndStatusAsync(
        string userId,
        ApplicationStatus applicationStatus)
    {
        return await Applications
            .FirstOrDefaultAsync(a => a.UserId == userId && a.ApplicationStatus == ApplicationStatus.Draft);
    }

    public async Task<Application> GetFullApplicationByIdAsync(int applicationId)
    {
        return await _repository.Entities
            .Include(a => a.AdditionalDocumentList).ThenInclude(ad => ad.AdditionalDocuments)
            .Include(a => a.AdditionalInformation)
            .Include(a => a.AddressList)
            .Include(a => a.Affidavit)
            .Include(a => a.ApplicationCertificationAgencies).ThenInclude(aca => aca.CertificationAgency)
            .Include(a => a.Capability).ThenInclude(c => c.NaicsCodes)
            .Include(a => a.Capability).ThenInclude(c => c.SicCodes)
            .Include(a => a.Capability).ThenInclude(c => c.UkSicCodes)
            .Include(a => a.Capability).ThenInclude(c => c.UnspscCodes)
            .Include(a => a.Capability).ThenInclude(c => c.UnNumberCodes)
            .Include(a => a.Company).ThenInclude(c => c.Contractor)
            .Include(a => a.Company).ThenInclude(c => c.LegalStructureList).ThenInclude(c => c.LegalStructureDocuments)
            .Include(a => a.Company).ThenInclude(c => c.Documents)
            .Include(a => a.ContractReferenceList)
            .Include(a => a.DisabilityImpact).ThenInclude(c => c.DisabilityImpactDocuments)
            .Include(a => a.DiversityList)
            .Include(a => a.Equipments)
            .Include(a => a.FinancialSizeInfo).ThenInclude(m => m.Incomes)
            .Include(a => a.ManagementAtOutsideFirm).ThenInclude(m => m.OutsideFirmIndividuals)
            .Include(a => a.ManagementChange).ThenInclude(m => m.ManagementChangeAgreements)
            .Include(a => a.ManagementContributions)
            .Include(a => a.ManagementResponsibility).ThenInclude(r => r.ManagementResponsibilityOwners)
            .Include(a => a.RealEstate).ThenInclude(ra => ra.Facilities).ThenInclude(f => f.Address)
            .Include(a => a.TransportationDetail)
            .Include(a => a.TrustDetail)
            .Include(a => a.Vehicles)
            .Where(p => p.ApplicationId == applicationId)
            .FirstOrDefaultAsync();
    }

    // @formatter:off
    public Task<Application> GetApplicationByIdAllSubPropertiesAsync(int applicationId)
    {
        return _repository.Entities
            .Include(a => a.AdditionalDocumentList).ThenInclude(ad => ad.AdditionalDocuments).ThenInclude(ad => ad.Document)
            .Include(a => a.AdditionalInformation).ThenInclude(a => a.BankruptcyDocument)
            .Include(a => a.AdditionalInformation).ThenInclude(a => a.CertificationDenialDocument)
            .Include(a => a.AdditionalInformation).ThenInclude(a => a.LawsuitDocument)
            .Include(a => a.AdditionalInformation).ThenInclude(a => a.SiteVisitAccomodationRequirementsDocument)
            .Include(a => a.AddressList)
            .Include(a => a.Affidavit)
            .Include(a => a.ApplicationCertificationAgencies).ThenInclude(aca => aca.CertificationAgency)
            .Include(a => a.ApplicationCertificationAgencies).ThenInclude(aca => aca.Document)
            .Include(a => a.BankAndCreditReferences).ThenInclude(i => i.Address)
            .Include(a => a.BusinessRelationships).ThenInclude(i => i.Address)
            .Include(a => a.Capability).ThenInclude(c => c.NaicsCodes)
            .Include(a => a.Capability).ThenInclude(c => c.SicCodes)
            .Include(a => a.Capability).ThenInclude(c => c.UkSicCodes)
            .Include(a => a.Capability).ThenInclude(c => c.UnspscCodes)
            .Include(a => a.Capability).ThenInclude(c => c.UnNumberCodes)
            .Include(a => a.Company)
            .Include(a => a.Company).ThenInclude(c => c.Contractor).ThenInclude(c => c.Document)
            .Include(a => a.Company).ThenInclude(c => c.Documents)
            .Include(a => a.Company).ThenInclude(c => c.LegalStructureList).ThenInclude(c => c.LegalStructureDocuments)
            .Include(a => a.ContractReferenceList).ThenInclude(i => i.Address)
            .Include(a => a.DisabilityImpact).ThenInclude(d => d.DisabilityImpactDocuments)
            .Include(a => a.DiversityList).ThenInclude(d => d.Document)
            .Include(a => a.Equipments).ThenInclude(e => e.Document)
            .Include(a => a.FinancialSizeInfo).ThenInclude(f => f.Document)
            .Include(a => a.FinancialSizeInfo).ThenInclude(f => f.Incomes).ThenInclude(i => i.Document)
            .Include(a => a.ManagementAtOutsideFirm).ThenInclude(m => m.OutsideFirmIndividuals).ThenInclude(o => o.Document)
            .Include(a => a.ManagementChange).ThenInclude(m => m.ManagementChangeAgreements).ThenInclude(a => a.Document)
            .Include(a => a.ManagementContributions).ThenInclude(m => m.Owner)
            .Include(a => a.ManagementResponsibility).ThenInclude(r => r.ManagementResponsibilityOwners).ThenInclude(o => o.Document)
            .Include(a => a.PaymentDetail)
            .Include(a => a.RealEstate).ThenInclude(ra => ra.Facilities).ThenInclude(f => f.Address)
            .Include(a => a.RealEstate).ThenInclude(ra => ra.Facilities).ThenInclude(f => f.Document)
            .Include(a => a.TransportationDetail).ThenInclude(t => t.ContractDocument)
            .Include(a => a.TransportationDetail).ThenInclude(t => t.LeaseDocument)
            .Include(a => a.TrustDetail).ThenInclude(t => t.Document)
            .Include(a => a.Owners).ThenInclude(t => t.Document)
            .Include(a => a.Vehicles).ThenInclude(v => v.Document)
            .Where(p => p.ApplicationId == applicationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
    // @formatter:on

    public Task<Application> GetByReferenceAsync(
        string applicationReference,
        params ApplicationPropertyType[] applicationPropertyTypes)
    {
        return GetQueryableApplicationWithProperties(applicationPropertyTypes)
            .FirstOrDefaultAsync(a => a.ApplicationReference == applicationReference);
    }

    public Task<Application> GetByIdAsync(
        int applicationId,
        params ApplicationPropertyType[] applicationPropertyTypes)
    {
        return GetQueryableApplicationWithProperties(applicationPropertyTypes)
            .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);
    }

    public async Task<List<Application>> GetListAsync()
    {
        return await _repository.Entities
            .Include(a => a.Company)
            .OrderByDescending(a => a.ApplicationSubmittedDate).ThenByDescending(a => a.UpdatedBy)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(int applicationId)
    {
        return await _repository.Entities.AnyAsync(p => p.ApplicationId == applicationId);
    }

    public async Task<bool> ExistsWithStatusAsync(int applicationId, ApplicationStatus status)
    {
        return await _repository.Entities.AnyAsync(p => p.ApplicationId == applicationId &&
                                                        p.ApplicationStatus == status);
    }

    public async Task<bool> ExistsByReferenceAsync(string applicationReference)
    {
        return await _repository.Entities.AnyAsync(p => p.ApplicationReference == applicationReference);
    }

    public async Task<int> InsertAsync(Application application)
    {
        await _repository.AddAsync(application);
        return application.ApplicationId;
    }

    public async Task UpdateAsync(Application application)
    {
        await _repository.UpdateAsync(application);
    }

    public async Task<List<Application>> GetApplicationsByUserIdAsync(string userId)
    {
        return await Applications
            .Include(a => a.Company)
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.ApplicationSubmittedDate).ThenByDescending(a => a.UpdatedBy)
            .ToListAsync();
    }

    public Task<bool> IsUsaBasedCompanyAsync(int applicationId)
    {
        return _repository.Entities
            .AnyAsync(a => a.ApplicationId == applicationId && a.ApplicationUser.IsUSABasedCompany);
    }

    public Task<ApplicationUser> GetApplicationUserAsync(int applicationId)
    {
        return _repository.Entities
            .Where(a => a.ApplicationId == applicationId)
            .Select(a => a.ApplicationUser)
            .FirstOrDefaultAsync();
    }

    public Task<List<Application>> GetAssignedApplications(string userId)
    {
        return _repository.Entities
            .Include(a => a.Company)
            .Where(a => a.ApplicationAssignees.Any(aa => aa.UserId == userId))
            .OrderByDescending(a => a.ApplicationSubmittedDate).ThenByDescending(a => a.UpdatedBy)
            .ToListAsync();
    }

    private IQueryable<Application> GetQueryableApplicationWithProperties(
        ApplicationPropertyType[] applicationPropertyTypes)
    {
        var queryable = _repository.Entities;

        if (applicationPropertyTypes.Contains(ApplicationPropertyType.Affidavit))
            queryable = queryable.Include(a => a.Affidavit);

        if (applicationPropertyTypes.Contains(ApplicationPropertyType.Invoice))
            queryable = queryable
                .Include(a => a.Invoice).ThenInclude(i => i.InvoiceItems)
                .Include(a => a.Invoice).ThenInclude(i => i.Payment).ThenInclude(p => p.PaymentIntent);

        if (applicationPropertyTypes.Contains(ApplicationPropertyType.PaymentDetail))
            queryable = queryable.Include(a => a.PaymentDetail);

        if (applicationPropertyTypes.Contains(ApplicationPropertyType.ApplicationUser))
            queryable = queryable.Include(a => a.ApplicationUser);

        return queryable;
    }
}