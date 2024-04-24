using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IManagementChangeRepository
{
    Task<ManagementChange> GetManagementChangeByIdAsync(int managementChangeId);
}