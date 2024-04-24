using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IAdditionalDocumentRepository
{
    Task<AdditionalDocument> GetByIdAsync(int additionalDocumentId);
    Task<AdditionalDocument> CreateAsync(AdditionalDocument additionalDocument);
    Task UpdateAsync(AdditionalDocument additionalDocument);
    Task DeleteAsync(AdditionalDocument additionalDocument);
    Task<AdditionalDocument> GetByDocumentIdAsync(int documentId);
}