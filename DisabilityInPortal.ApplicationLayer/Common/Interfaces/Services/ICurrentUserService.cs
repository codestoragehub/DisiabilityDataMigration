using System.Security.Claims;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface ICurrentUserService
{
    ClaimsPrincipal User { get; }
    string UserId { get; }
    string Username { get; }
    bool IsApplicant();
    bool IsAdmin();
    bool IsManagement();
    bool IsAssignment();
}