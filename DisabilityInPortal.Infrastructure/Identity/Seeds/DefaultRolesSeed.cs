using System.Threading.Tasks;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Helpers;
using DisabilityInPortal.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.Infrastructure.Identity.Seeds
{
    public static class DefaultRolesSeed
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            foreach (var role in EnumHelper<Roles>.GetEnumValues())
            {
                var roleName = role.ToString();
                if (!await roleManager.RoleExistsAsync(roleName))
                    await roleManager.CreateAsync(new ApplicationRole(roleName));
            }
        }
    }
}