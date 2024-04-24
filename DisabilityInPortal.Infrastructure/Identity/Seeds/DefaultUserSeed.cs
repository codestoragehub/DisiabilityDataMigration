﻿using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DisabilityInPortal.Infrastructure.Identity.Seeds
{
    public static class DefaultUserSeed
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "basicuser@localhost.com",
                Email = "basicuser@localhost.com",
                FirstName = "System",
                LastName = "User",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "2021@Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Applicant.ToString());
                }
            }
        }
    }
}