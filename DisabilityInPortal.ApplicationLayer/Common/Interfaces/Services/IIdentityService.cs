using DisabilityInPortal.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface IIdentityService
    {
        ApplicationUser GetUserById(string UserId);
        Task<ApplicationUser> GetUserByIdAsync(string UserId);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserAsync(ClaimsPrincipal user);
    }
}
