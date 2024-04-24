using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IBankAndCreditReferenceRepository
{
    Task<BankAndCreditReference> GetBankAndCreditReferenceByIdAsync(int bankAndCreditReferenceId);
    Task<BankAndCreditReference> CreateBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference);
    Task UpdateBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference);
    Task DeleteBankAndCreditReferenceAsync(BankAndCreditReference bankAndCreditReference);
    Task<List<BankAndCreditReference>> GetListAsync();
    Task<List<BankAndCreditReference>> GetListByApplicationIdAsync(int applicationId);
    Task<BankAndCreditReference> GetByDocumentIdAsync(int documentId);
    Task<BankAndCreditReference> GetByLoanAgreementDocumentIdAsync(int loanAgreementDocumentId);
}