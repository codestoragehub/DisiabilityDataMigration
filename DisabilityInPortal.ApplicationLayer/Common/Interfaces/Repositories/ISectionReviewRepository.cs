using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ISectionReviewRepository
{
    Task<List<SectionReview>> GetListAsync(int applicationId, string userId, string roleId, ReviewType reviewType);

    Task<SectionReview> GetSectionReviewAsync(
        int applicationId,
        string userId,
        string roleId,
        SectionType sectionType,
        ReviewType reviewType);

    Task<List<SectionReview>> GetSectionReviewListByApplicationIdAsync(int applicationId);
    Task<SectionReview> GetSectionReviewByIdAsync(int sectionReviewId);
    Task<int> InsertAsync(SectionReview sectionReview);
    Task UpdateAsync(SectionReview sectionReview);
    Task RemoveRange(IEnumerable<SectionReview> sectionReview);
    Task AddRangeSectionReview(IEnumerable<SectionReview> sectionReviews);
}