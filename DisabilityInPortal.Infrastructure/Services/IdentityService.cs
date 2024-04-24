using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Services
{
    public  class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;           
        }

        public ApplicationUser GetUserById(string userId)
        {
            var appUser = GetUserByIdAsync(userId).Result;
            return appUser;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string userEmail)
        {
            return await _userManager.FindByEmailAsync(userEmail);
        }

        public async Task<ApplicationUser> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
    }
}
