using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ISiteVisitReviewRepository
{
    Task<SiteVisitReview> GetSiteVisitDetailByApplicationIdAsync(int applicationId);
    Task<SiteVisitReview> GetSiteVisitDetailByIdAsync(int siteVisitReviewId);
    Task<int> InsertAsync(SiteVisitReview siteVisitReview);
    Task UpdateAsync(SiteVisitReview siteVisitReview);
}