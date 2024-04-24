using System;
using System.Security.Claims;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

namespace DisabilityInPortal.Infrastructure.Services;

public class DesignTimeCurrentUserService : ICurrentUserService
{
    public ClaimsPrincipal User => throw new NotImplementedException("Not available on design time");
    public string UserId => "DesignTime";
    public string Username => "DesignTime";

    public bool IsApplicant()
    {
        throw new NotImplementedException("Not available on design time");
    }

    public bool IsManagement()
    {
        throw new NotImplementedException("Not available on design time");
    }

    public bool IsAssignment()
    {
        throw new NotImplementedException("Not available on design time");
    }

    public bool IsAdmin()
    {
        throw new NotImplementedException("Not available on design time");
    }
}