using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;
public class SiteVisitReviewOtherOwnerRepository : ISiteVisitReviewOtherOwnerRepository
{
    private readonly IRepositoryAsync<SiteVisitOtherOwner> _repository;

    public SiteVisitReviewOtherOwnerRepository(IRepositoryAsync<SiteVisitOtherOwner> repository)
    {
        _repository = repository;
    }

    public Task<List<SiteVisitOtherOwner>> GetSiteVisitOtherOwnersAsync(int siteVisitReviewId)
    {
        return _repository.Entities
            .Where(s => s.SiteVisitReviewId == siteVisitReviewId)
            .Include(s => s.SiteVisitReview)
            .Include(s => s.Owner)
            .ToListAsync();
    }

    public Task<SiteVisitOtherOwner> GetSiteVisitOtherOwnerByIdAsync(int siteVisitOtherOwnerId)
    {
        return _repository.Entities
            .Where(s => s.SiteVisitOtherOwnerId == siteVisitOtherOwnerId)
            .Include(s => s.SiteVisitReview)
            .Include(s => s.Owner)
            .FirstOrDefaultAsync();
    }

    public Task<SiteVisitOtherOwner> CreateSiteVisitOtherOwnerAsync(
        SiteVisitOtherOwner siteVisitOtherOwner)
    {
        return _repository.AddAsync(siteVisitOtherOwner);
    }

    public async Task UpdateSiteVisitOtherOwnerAsync(SiteVisitOtherOwner siteVisitOtherOwner)
    {
        await _repository.UpdateAsync(siteVisitOtherOwner);
    }

    public async Task DeleteSiteVisitOtherOwnerAsync(SiteVisitOtherOwner siteVisitOtherOwner)
    {
        await _repository.DeleteAsync(siteVisitOtherOwner);
    }

    public Task<bool> ExistingSiteVisitOtherOwnerAsync(int siteVisitReviewId, int ownerId)
    {
        return _repository.Entities.AnyAsync(s => s.SiteVisitReviewId == siteVisitReviewId && s.OwnerId == ownerId);
    }
}
