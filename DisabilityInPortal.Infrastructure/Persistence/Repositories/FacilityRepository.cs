using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class FacilityRepository : IFacilityRepository
{
    private readonly IRepositoryAsync<Facility> _repository;

    public FacilityRepository(IRepositoryAsync<Facility> repository)
    {
        _repository = repository;
    }

    public Task<Facility> GetFacilityByIdAsync(int facilityId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Include(f => f.Document)
            .Where(f => f.FacilityId == facilityId)
            .FirstOrDefaultAsync();
    }

    public Task<Facility> CreateFacilityAsync(Facility facility)
    {
        return _repository.AddAsync(facility);
    }

    public async Task UpdateFacilityAsync(Facility facility)
    {
        await _repository.UpdateAsync(facility);
    }

    public async Task DeleteFacilityAsync(Facility facility)
    {
        await _repository.DeleteAsync(facility);
    }

    public Task<Facility> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
    }
}