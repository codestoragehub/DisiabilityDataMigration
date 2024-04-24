using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ManagementResponsibilityOwnerRepository : IManagementResponsibilityOwnerRepository
{
    private readonly IRepositoryAsync<ManagementResponsibilityOwner> _repository;

    public ManagementResponsibilityOwnerRepository(IRepositoryAsync<ManagementResponsibilityOwner> repository)
    {
        _repository = repository;
    }

    public Task<ManagementResponsibilityOwner> GetManagementResponsibilityOwnerByIdAsync(
        int managementResponsibilityOwnerId)
    {
        return _repository.Entities
            .Include(f => f.Document)
            .Include(f => f.ManagementResponsibility)
            .Where(f => f.ManagementResponsibilityOwnerId == managementResponsibilityOwnerId)
            .FirstOrDefaultAsync();
    }

    public Task<ManagementResponsibilityOwner> CreateManagementResponsibilityOwnerAsync(
        ManagementResponsibilityOwner managementResponsibilityOwner)
    {
        return _repository.AddAsync(managementResponsibilityOwner);
    }

    public Task<bool> ExistsByOwnerId(int ownerId)
    {
        return _repository.Entities.AnyAsync(r => r.OwnerId == ownerId);
    }

    public async Task UpdateManagementResponsibilityOwnerAsync(
        ManagementResponsibilityOwner managementResponsibilityOwner)
    {
        await _repository.UpdateAsync(managementResponsibilityOwner);
    }

    public async Task DeleteManagementResponsibilityOwnerAsync(
        ManagementResponsibilityOwner managementResponsibilityOwner)
    {
        await _repository.DeleteAsync(managementResponsibilityOwner);
    }

    public Task<ManagementResponsibilityOwner> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(m => m.DocumentId == documentId);
    }
}