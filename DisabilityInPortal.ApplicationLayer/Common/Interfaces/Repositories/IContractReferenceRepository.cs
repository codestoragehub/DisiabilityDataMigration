using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IContractReferenceRepository
{
    Task<ContractReference> GetContractReferenceByIdAsync(int contractReferencesId);
    Task<List<ContractReference>> GetContractReferenceByApplicationIdAsync(int applicationId);
    Task<ContractReference> CreateContractReferenceAsync(ContractReference contractReference);
    Task UpdateContractReferenceAsync(ContractReference contractReference);
    Task DeleteContractReferenceAsync(ContractReference contractReference);
    Task<List<ContractReference>> GetListAsync();
    Task<ContractReference> GetByDocumentIdAsync(int documentId);
}