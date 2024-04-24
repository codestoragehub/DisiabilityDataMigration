using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ManagementChangeAgreementRepository : IManagementChangeAgreementRepository
{
    private readonly IRepositoryAsync<ManagementChangeAgreement> _repository;

    public ManagementChangeAgreementRepository(IRepositoryAsync<ManagementChangeAgreement> repository)
    {
        _repository = repository;
    }

    public Task<ManagementChangeAgreement> GetManagementChangeAgreementByIdAsync(int managementChangeAgreementId)
    {
        return _repository.Entities
            .Include(f => f.Document)
            .Include(m => m.ManagementChange)
            .Where(f => f.ManagementChangeAgreementId == managementChangeAgreementId)
            .FirstOrDefaultAsync();
    }

    public Task<ManagementChangeAgreement> CreateManagementChangeAgreementAsync(
        ManagementChangeAgreement managementChangeAgreement)
    {
        return _repository.AddAsync(managementChangeAgreement);
    }

    public Task UpdateManagementChangeAgreementAsync(ManagementChangeAgreement managementChangeAgreement)
    {
        return _repository.UpdateAsync(managementChangeAgreement);
    }

    public Task DeleteManagementChangeAgreementAsync(ManagementChangeAgreement managementChangeAgreement)
    {
        return _repository.DeleteAsync(managementChangeAgreement);
    }

    public Task<ManagementChangeAgreement> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
    }
}