using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ISiteVisitReviewOtherOwnerRepository
{
    Task<List<SiteVisitOtherOwner>> GetSiteVisitOtherOwnersAsync(int siteVisitReviewId);
    Task<SiteVisitOtherOwner> GetSiteVisitOtherOwnerByIdAsync(int siteVisitOtherOwnerId);
    Task<SiteVisitOtherOwner> CreateSiteVisitOtherOwnerAsync(SiteVisitOtherOwner siteVisitOtherOwner);
    Task UpdateSiteVisitOtherOwnerAsync(SiteVisitOtherOwner siteVisitOtherOwner);
    Task DeleteSiteVisitOtherOwnerAsync(SiteVisitOtherOwner siteVisitOtherOwner);
    Task<bool> ExistingSiteVisitOtherOwnerAsync(int siteVisitReviewId, int ownerId);
}
