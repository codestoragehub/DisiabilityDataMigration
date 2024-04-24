using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class AdditionalDocumentListRepository : IAdditionalDocumentListRepository
{
    private readonly IRepositoryAsync<AdditionalDocumentList> _repository;

    public AdditionalDocumentListRepository(IRepositoryAsync<AdditionalDocumentList> repository)
    {
        _repository = repository;
    }

    public async Task<AdditionalDocumentList> GetByIdAsync(int additionalDocumentListId)
    {
        return await _repository.Entities
            .Include(r => r.AdditionalDocuments)
            .Where(r => r.AdditionalDocumentListId == additionalDocumentListId)
            .FirstOrDefaultAsync();
    }
}