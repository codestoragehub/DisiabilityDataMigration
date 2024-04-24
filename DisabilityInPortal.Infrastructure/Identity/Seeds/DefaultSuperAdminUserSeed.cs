using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Constants;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Helpers;
using DisabilityInPortal.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.Infrastructure.Identity.Seeds
{
    public static class DefaultSuperAdminUserSeed
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@localhost.com",
                Email = "superadmin@localhost.com",
                FirstName = "System",
                LastName = "SuperAdmin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "2021Super@Pa$$word!");

                    foreach (var role in EnumHelper<Roles>.GetEnumValues())
                        await userManager.AddToRoleAsync(defaultUser, role.ToString());
                }

                await roleManager.SeedClaimsForSuperAdmin();
            }
        }

        private static async Task SeedClaimsForSuperAdmin(this RoleManager<ApplicationRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Users");
        }

        private static async Task AddPermissionClaim(
            this RoleManager<ApplicationRole> roleManager,
            ApplicationRole role,
            string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = PermissionsGenerator.GeneratePermissionsForModule(module);

            foreach (var permission in allPermissions)
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, permission));
        }
    }
}