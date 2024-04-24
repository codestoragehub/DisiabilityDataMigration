using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class BankAndCreditReferenceRepository : IBankAndCreditReferenceRepository
{
    private readonly IRepositoryAsync<BankAndCreditReference> _repository;

    public BankAndCreditReferenceRepository(IRepositoryAsync<BankAndCreditReference> repository)
    {
        _repository = repository;
    }

    public Task<BankAndCreditReference> GetBankAndCreditReferenceByIdAsync(int bankAndCreditReferenceId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Include(f => f.Document)
            .Include(f => f.LoanAgreementDocument)
            .Where(f => f.BankAndCreditReferenceId == bankAndCreditReferenceId)
            .FirstOrDefaultAsync();
    }

    public Task<BankAndCreditReference> CreateBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference)
    {
        return _repository.AddAsync(bankAndCreditReference);
    }

    public async Task UpdateBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference)
    {
        await _repository.UpdateAsync(bankAndCreditReference);
    }

    public async Task DeleteBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference)
    {
        await _repository.DeleteAsync(bankAndCreditReference);
    }

    public Task<List<BankAndCreditReference>> GetListAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<List<BankAndCreditReference>> GetListByApplicationIdAsync(int applicationId)
    {
        return _repository.Entities
            .Include(f => f.Address)
            .Include(f => f.Document)
            .Include(f => f.LoanAgreementDocument)
            .Where(f => f.ApplicationId == applicationId).ToListAsync();
    }

    public Task<BankAndCreditReference> GetByDocumentIdAsync(int documentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
    }

    public Task<BankAndCreditReference> GetByLoanAgreementDocumentIdAsync(int loanAgreementDocumentId)
    {
        return _repository.Entities.FirstOrDefaultAsync(aca => aca.LoanAgreementDocumentId == loanAgreementDocumentId);
    }
}