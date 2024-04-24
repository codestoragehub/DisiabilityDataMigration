using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IApplicationUserRepository
{
    Task<bool> ExistsByReferenceAsync(string userReference);
    Task<List<ApplicationUser>> GetUsersInRolesAsync(IReadOnlyCollection<string> roles);
}