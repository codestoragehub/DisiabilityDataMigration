using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IManagementResponsibilityRepository
{
    Task<ManagementResponsibility> GetManagementResponsibilityByIdAsync(int managementResponsibilityId);
}