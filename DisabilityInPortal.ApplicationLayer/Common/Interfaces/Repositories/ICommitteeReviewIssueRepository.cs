using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ICommitteeReviewIssueRepository
{
    Task<List<CommitteeReviewIssue>> GetCommitteeReviewIssuesAsync(int siteVisitReviewId);
    Task<CommitteeReviewIssue> GetCommitteeReviewIssueByIdAsync(int committeeReviewIssueId);
    Task<CommitteeReviewIssue> CreateCommitteeReviewIssueAsync(CommitteeReviewIssue committeeReviewIssue);
    Task UpdateCommitteeReviewIssueAsync(CommitteeReviewIssue committeeReviewIssue);
    Task DeleteCommitteeReviewIssueAsync(CommitteeReviewIssue committeeReviewIssue);
}