using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ISiteVisitReviewOwnerRepository
{
    Task<List<SiteVisitReviewOwner>> GetSiteVisitReviewOwnersAsync(int siteVisitReviewId);
    Task<SiteVisitReviewOwner> GetSiteVisitReviewOwnerByIdAsync(int siteVisitReviewOwnerId);
    Task<SiteVisitReviewOwner> CreateSiteVisitReviewOwnerAsync(SiteVisitReviewOwner siteVisitReviewOwner);
    Task UpdateSiteVisitReviewOwnerAsync(SiteVisitReviewOwner siteVisitReviewOwner);
    Task DeleteSiteVisitReviewOwnerAsync(SiteVisitReviewOwner siteVisitReviewOwner);
    Task<bool> ExistingSiteVisitReviewOwnerAsync(int siteVisitReviewId, int ownerId);
}