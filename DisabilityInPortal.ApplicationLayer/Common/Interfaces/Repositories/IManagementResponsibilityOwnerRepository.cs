using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IManagementResponsibilityOwnerRepository
{
    Task<ManagementResponsibilityOwner> GetManagementResponsibilityOwnerByIdAsync(int managementResponsibilityOwnerId);

    Task<ManagementResponsibilityOwner> CreateManagementResponsibilityOwnerAsync(
        ManagementResponsibilityOwner managementResponsibilityOwner);

    Task<bool> ExistsByOwnerId(int ownerId);

    Task UpdateManagementResponsibilityOwnerAsync(ManagementResponsibilityOwner managementResponsibilityOwner);
    Task DeleteManagementResponsibilityOwnerAsync(ManagementResponsibilityOwner managementResponsibilityOwner);
    Task<ManagementResponsibilityOwner> GetByDocumentIdAsync(int documentId);
}