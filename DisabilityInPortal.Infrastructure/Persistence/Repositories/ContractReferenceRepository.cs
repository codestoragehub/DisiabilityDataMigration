using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ContractReferenceRepository : IContractReferenceRepository
{
    private readonly IRepositoryAsync<ContractReference> _repository;

    public ContractReferenceRepository(IRepositoryAsync<ContractReference> repository)
    {
        _repository = repository;
    }

    public Task<ContractReference> GetContractReferenceByIdAsync(int contractReferenceId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Where(f => f.ContractReferenceId == contractReferenceId)
            .FirstOrDefaultAsync();
    }

    public Task<List<ContractReference>> GetContractReferenceByApplicationIdAsync(int applicationId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Where(f => f.ApplicationId == applicationId).ToListAsync();
    }


    public Task<ContractReference> CreateContractReferenceAsync(ContractReference contractReference)
    {
        return _repository.AddAsync(contractReference);
    }

    public async Task UpdateContractReferenceAsync(ContractReference contractReference)
    {
        await _repository.UpdateAsync(contractReference);
    }

    public async Task DeleteContractReferenceAsync(ContractReference contractReference)
    {
        await _repository.DeleteAsync(contractReference);
    }

    public Task<List<ContractReference>> GetListAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<ContractReference> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(cr => cr.DocumentId == documentId);
    }
}