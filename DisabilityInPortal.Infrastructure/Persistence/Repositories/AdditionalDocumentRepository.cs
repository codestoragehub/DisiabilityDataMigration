using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class AdditionalDocumentRepository : IAdditionalDocumentRepository
{
    private readonly IRepositoryAsync<AdditionalDocument> _repository;

    public AdditionalDocumentRepository(IRepositoryAsync<AdditionalDocument> repository)
    {
        _repository = repository;
    }

    public Task<AdditionalDocument> GetByIdAsync(int additionalDocumentId)
    {
        return _repository.Entities
            .Include(o => o.Document)
            .Include(o => o.AdditionalDocumentList)
            .Where(f => f.AdditionalDocumentId == additionalDocumentId)
            .FirstOrDefaultAsync();
    }

    public Task<AdditionalDocument> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities
            .Where(f => f.DocumentId == documentId)
            .FirstOrDefaultAsync();
    }

    public Task<AdditionalDocument> CreateAsync(AdditionalDocument outsideFirmIndividual)
    {
        return _repository.AddAsync(outsideFirmIndividual);
    }

    public Task UpdateAsync(AdditionalDocument outsideFirmIndividual)
    {
        return _repository.UpdateAsync(outsideFirmIndividual);
    }

    public Task DeleteAsync(AdditionalDocument outsideFirmIndividual)
    {
        return _repository.DeleteAsync(outsideFirmIndividual);
    }
}