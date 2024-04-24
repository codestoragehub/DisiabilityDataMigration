using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class SectionReviewRepository : ISectionReviewRepository
{
    private readonly IRepositoryAsync<SectionReview> _repository;

    public SectionReviewRepository(IRepositoryAsync<SectionReview> repository)
    {
        _repository = repository;
    }

    public async Task<List<SectionReview>> GetListAsync(
        int applicationId,
        string userId,
        string roleId,
        ReviewType reviewType)
    {
        return await _repository.Entities
            .Where(a => a.UserId == userId &&
                        a.ApplicationId == applicationId &&
                        a.RoleId == roleId &&
                        a.ReviewType == reviewType)
            .ToListAsync();
    }

    public Task<SectionReview> GetSectionReviewAsync(
        int applicationId, 
        string userId,
        string roleId,
        SectionType sectionType,
        ReviewType reviewType)
    {
        return _repository.Entities
            .Where(a => a.UserId == userId &&
                        a.ApplicationId == applicationId &&
                        a.RoleId == roleId &&
                        a.SectionType == sectionType &&
                        a.ReviewType == reviewType)
            .FirstOrDefaultAsync();
    }

    public async Task<List<SectionReview>> GetSectionReviewListByApplicationIdAsync(int applicationId)
    {
        return await _repository.Entities
            .Where(r => r.ApplicationId == applicationId)
            .ToListAsync();
    }

    public async Task<SectionReview> GetSectionReviewByIdAsync(int sectionReviewId)
    {
        return await _repository.Entities
            .Where(sr => sr.SectionReviewId == sectionReviewId).FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(SectionReview sectionReview)
    {
        await _repository.AddAsync(sectionReview);
        return sectionReview.SectionReviewId;
    }

    public async Task UpdateAsync(SectionReview sectionReview)
    {
        await _repository.UpdateAsync(sectionReview);
    }

    public async Task RemoveRange(IEnumerable<SectionReview> sectionReviewList)
    {
        await _repository.RemoveRange(sectionReviewList);
    }

    public async Task AddRangeSectionReview(IEnumerable<SectionReview> sectionReviewList)
    {
        await _repository.AddRange(sectionReviewList);
    }
}