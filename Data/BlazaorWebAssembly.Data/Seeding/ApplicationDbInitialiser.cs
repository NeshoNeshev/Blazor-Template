using BlazorWebAssembly.Common;
using BlazorWebAssembly.Data.Models.ApplicationModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace BlazorWebAssembly.Data.Seeding
{
    public static class ApplicationDbInitialiser
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            AddRoles(roleManager, GlobalConstants.AdministratorRoleName);
            AddRoles(roleManager, GlobalConstants.ModeratorRoleName);
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            (string name, string password, string role)[] demoUsers = new[]
            {
                (name: GlobalConstants.AdministratorUserName, password: GlobalConstants.AdministratorPassword, role: GlobalConstants.AdministratorRoleName),
                (name: GlobalConstants.ModeratorUserName, password: GlobalConstants.ModeratorPassword, role: GlobalConstants.ModeratorRoleName),

            };

            foreach ((string name, string password, string role) user in demoUsers)
            {
                AddUsers(userManager, user);
            }

        }

        private static void AddUsers(UserManager<ApplicationUser> userManager, (string name, string password, string role) demoUser)
        {
            ApplicationUser user = userManager.FindByNameAsync(demoUser.name).Result;
            if (user == default)
            {
                var newAppUser = new ApplicationUser
                {
                    UserName = demoUser.name,
                    Email = demoUser.name,
                    EmailConfirmed = true
                };
                _ = userManager.CreateAsync(newAppUser, demoUser.password).Result;
                if (!string.IsNullOrWhiteSpace(demoUser.role))
                {
                    var roles = demoUser.role.Split(',').Select(a => a.Trim()).ToArray();
                    Console.WriteLine($"{roles.Length}");
                    foreach (var role in roles)
                    {
                        _ = userManager.AddToRoleAsync(newAppUser, role).Result;

                    }
                }

            }
        }
        private static void AddRoles(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.FindByNameAsync(roleName).Result == default)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName }).Wait();
            }
        }
    }
}
