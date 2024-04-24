using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class SupplierProfileContractReferenceRepository : ISupplierProfileContractReferenceRepository
{
    private readonly IRepositoryAsync<SupplierProfileContractReference> _repository;

    public SupplierProfileContractReferenceRepository(IRepositoryAsync<SupplierProfileContractReference> repository)
    {
        _repository = repository;
    }

    public Task<SupplierProfileContractReference> GetSupplierProfileContractReferenceByIdAsync(int supplierProfileContractReferenceId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Where(f => f.SupplierProfileContractReferenceId == supplierProfileContractReferenceId)
            .FirstOrDefaultAsync();
    }

    public Task<List<SupplierProfileContractReference>> GetSupplierProfileContractReferenceBySupplierProfileIdAsync(int supplierProfileId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Where(f => f.SupplierProfileId == supplierProfileId).ToListAsync();
    }


    public Task<SupplierProfileContractReference> CreateSupplierProfileContractReferenceAsync(SupplierProfileContractReference supplierProfileContractReference)
    {
        return _repository.AddAsync(supplierProfileContractReference);
    }

    public async Task UpdateSupplierProfileContractReferenceAsync(SupplierProfileContractReference supplierProfileContractReference)
    {
        await _repository.UpdateAsync(supplierProfileContractReference);
    }

    public async Task DeleteSupplierProfileContractReferenceAsync(SupplierProfileContractReference supplierProfileContractReference)
    {
        await _repository.DeleteAsync(supplierProfileContractReference);
    }

    public Task<List<SupplierProfileContractReference>> GetListAsync()
    {
        return _repository.GetAllAsync();
    }

}