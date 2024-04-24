using System.Linq;
using System.Security.Claims;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace DisabilityInPortal.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _accessor;

    public CurrentUserService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public ClaimsPrincipal User => _accessor?.HttpContext?.User;
    public string UserId => User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public string Username => User?.FindFirstValue(ClaimTypes.Name);

    public bool IsApplicant()
    {
        return !IsManagement();
    }

    public bool IsManagement()
    {
        return Constants.ManagementRoles.Any(r => User.IsInRole(r));
    }

    public bool IsAssignment()
    {
        return Constants.AssignmentRoles.Any(r => User.IsInRole(r));
    }

    public bool IsAdmin()
    {
        return Constants.AdminRoles.Any(r => User.IsInRole(r));
    }
}