using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IManagementChangeAgreementRepository
{
    Task<ManagementChangeAgreement> GetManagementChangeAgreementByIdAsync(int managementChangeAgreementId);
    Task<ManagementChangeAgreement> CreateManagementChangeAgreementAsync(ManagementChangeAgreement managementChangeAgreement);
    Task UpdateManagementChangeAgreementAsync(ManagementChangeAgreement managementChangeAgreement);
    Task DeleteManagementChangeAgreementAsync(ManagementChangeAgreement managementChangeAgreement);
    Task<ManagementChangeAgreement> GetByDocumentIdAsync(int documentId);
}