using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class CommitteeReviewIssueRepository : ICommitteeReviewIssueRepository
{
    private readonly IRepositoryAsync<CommitteeReviewIssue> _repository;

    public CommitteeReviewIssueRepository(IRepositoryAsync<CommitteeReviewIssue> repository)
    {
        _repository = repository;
    }

    public Task<List<CommitteeReviewIssue>> GetCommitteeReviewIssuesAsync(int siteVisitReviewId)
    {
        return _repository.Entities
            .Where(s => s.SiteVisitReviewId == siteVisitReviewId)
            .Include(s => s.SiteVisitReview)
            .ToListAsync();
    }

    public Task<CommitteeReviewIssue> GetCommitteeReviewIssueByIdAsync(int committeeReviewIssueId)
    {
        return _repository.Entities
            .Where(s => s.CommitteeReviewIssueId == committeeReviewIssueId)
            .Include(s => s.SiteVisitReview)
            .FirstOrDefaultAsync();
    }

    public Task<CommitteeReviewIssue> CreateCommitteeReviewIssueAsync(CommitteeReviewIssue committeeReviewIssue)
    {
        return _repository.AddAsync(committeeReviewIssue);
    }

    public async Task UpdateCommitteeReviewIssueAsync(CommitteeReviewIssue committeeReviewIssue)
    {
        await _repository.UpdateAsync(committeeReviewIssue);
    }

    public async Task DeleteCommitteeReviewIssueAsync(CommitteeReviewIssue committeeReviewIssue)
    {
        await _repository.DeleteAsync(committeeReviewIssue);
    }
}