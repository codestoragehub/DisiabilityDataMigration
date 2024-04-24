using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class SiteVisitReviewOwnerRepository : ISiteVisitReviewOwnerRepository
{
    private readonly IRepositoryAsync<SiteVisitReviewOwner> _repository;

    public SiteVisitReviewOwnerRepository(IRepositoryAsync<SiteVisitReviewOwner> repository)
    {
        _repository = repository;
    }

    public Task<List<SiteVisitReviewOwner>> GetSiteVisitReviewOwnersAsync(int siteVisitReviewId)
    {
        return _repository.Entities
            .Where(s => s.SiteVisitReviewId == siteVisitReviewId)
            .Include(s => s.SiteVisitReview)
            .Include(s => s.Owner)
            .ToListAsync();
    }

    public Task<SiteVisitReviewOwner> GetSiteVisitReviewOwnerByIdAsync(int siteVisitReviewOwnerId)
    {
        return _repository.Entities
            .Where(s => s.SiteVisitReviewOwnerId == siteVisitReviewOwnerId)
            .Include(s => s.SiteVisitReview)
            .Include(s => s.Owner)
            .FirstOrDefaultAsync();
    }

    public Task<SiteVisitReviewOwner> CreateSiteVisitReviewOwnerAsync(
        SiteVisitReviewOwner siteVisitReviewOwner)
    {
        return _repository.AddAsync(siteVisitReviewOwner);
    }

    public async Task UpdateSiteVisitReviewOwnerAsync(SiteVisitReviewOwner siteVisitReviewOwner)
    {
        await _repository.UpdateAsync(siteVisitReviewOwner);
    }

    public async Task DeleteSiteVisitReviewOwnerAsync(SiteVisitReviewOwner siteVisitReviewOwner)
    {
        await _repository.DeleteAsync(siteVisitReviewOwner);
    }

    public Task<bool> ExistingSiteVisitReviewOwnerAsync(int siteVisitReviewId, int ownerId)
    {
        return _repository.Entities.AnyAsync(s => s.SiteVisitReviewId == siteVisitReviewId && s.OwnerId == ownerId);
    }
}