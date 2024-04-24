using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly IRepositoryAsync<ApplicationUser> _repository;

    public ApplicationUserRepository(IRepositoryAsync<ApplicationUser> repository)
    {
        _repository = repository;
    }

    private IQueryable<ApplicationUser> ApplicationUsers => _repository.Entities;

    public async Task<bool> ExistsByReferenceAsync(string userReference)
    {
        return await _repository.Entities.AnyAsync(u => u.UserReference == userReference);
    }

    public Task<List<ApplicationUser>> GetUsersInRolesAsync(IReadOnlyCollection<string> roles)
    {
        return _repository.Entities
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            .Where(user => user.UserRoles.Any(userRole => roles.Contains(userRole.Role.Name)))
            .ToListAsync();
    }
}