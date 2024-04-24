using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class OutsideFirmIndividualRepository : IOutsideFirmIndividualRepository
{
    private readonly IRepositoryAsync<OutsideFirmIndividual> _repository;

    public OutsideFirmIndividualRepository(IRepositoryAsync<OutsideFirmIndividual> repository)
    {
        _repository = repository;
    }

    public Task<OutsideFirmIndividual> GetOutsideFirmIndividualByIdAsync(int outsideFirmIndividualId)
    {
        return _repository.Entities
            .Include(o => o.Document)
            .Include(o => o.ManagementAtOutsideFirm)
            .Where(f => f.OutsideFirmIndividualId == outsideFirmIndividualId)
            .FirstOrDefaultAsync();
    }

    public Task<OutsideFirmIndividual> CreateOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual)
    {
        return _repository.AddAsync(outsideFirmIndividual);
    }

    public Task UpdateOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual)
    {
        return _repository.UpdateAsync(outsideFirmIndividual);
    }

    public Task DeleteOutsideFirmIndividualAsync(OutsideFirmIndividual outsideFirmIndividual)
    {
        return _repository.DeleteAsync(outsideFirmIndividual);
    }

    public Task<OutsideFirmIndividual> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
    }

    public Task<bool> ExistsByOwnerId(int ownerId)
    {
        return _repository.Entities.AnyAsync(r => r.OwnerId == ownerId);
    }
}