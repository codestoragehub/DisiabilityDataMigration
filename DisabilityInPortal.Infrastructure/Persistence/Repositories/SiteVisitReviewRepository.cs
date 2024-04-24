using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class SiteVisitReviewRepository : ISiteVisitReviewRepository
{
    private readonly IRepositoryAsync<SiteVisitReview> _repository;

    public SiteVisitReviewRepository(IRepositoryAsync<SiteVisitReview> repository)
    {
        _repository = repository;
    }

    public Task<SiteVisitReview> GetSiteVisitDetailByIdAsync(int siteVisitReviewId)
    {
        return _repository.Entities
            .Include(s => s.Office)
            .Include(s => s.CompanyHistoryAndOwnership)
            .Include(s => s.SiteVisitReviewOwners).ThenInclude(a => a.Owner)
            .Include(s => s.ContributionOfCapitalAndExpertise)
            .Include(s => s.EmployeesCompensation)
            .Include(s => s.CommitteeReviewIssues)
            .Include(s => s.OperationAndControl)
            .Where(s => s.SiteVisitReviewId == siteVisitReviewId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(SiteVisitReview siteVisitReview)
    {
        await _repository.AddAsync(siteVisitReview);
        return siteVisitReview.SiteVisitReviewId;
    }

    public async Task UpdateAsync(SiteVisitReview siteVisitReview)
    {
        await _repository.UpdateAsync(siteVisitReview);
    }

    public Task<SiteVisitReview> GetSiteVisitDetailByApplicationIdAsync(int applicationId)
    {
        return _repository.Entities
            .Include(s => s.Office)
            .Include(s => s.CompanyHistoryAndOwnership)
            .Include(s => s.SiteVisitReviewOwners).ThenInclude(a => a.Owner)
            .Include(s => s.ContributionOfCapitalAndExpertise)
            .Include(s => s.EmployeesCompensation)
            .Include(s => s.CommitteeReviewIssues)
            .Include(s => s.OperationAndControl)
            .Where(s => s.ApplicationId == applicationId)
            .FirstOrDefaultAsync();
    }
}