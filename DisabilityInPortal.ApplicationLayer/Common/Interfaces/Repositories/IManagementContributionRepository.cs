using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IManagementContributionRepository
{
    Task<List<ManagementContribution>> GetManagementContributionsAsync(int applicationId);
    Task<ManagementContribution> GetManagementContributionByIdAsync(int managementContributionId);
    Task<ManagementContribution> CreateManagementContributionAsync(ManagementContribution managementContribution);
    Task UpdateManagementContributionAsync(ManagementContribution managementContribution);
    Task DeleteManagementContributionAsync(ManagementContribution managementContribution);
    Task<bool> ExistsByOwnerId(int ownerId);
}