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
            AddRoleIfNotExists(roleManager, GlobalConstants.AdministratorRoleName);
            AddRoleIfNotExists(roleManager, "Moderator");
            AddRoleIfNotExists(roleManager, "Company");
            AddRoleIfNotExists(roleManager, "Proffesional");
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            (string name, string password, string role)[] demoUsers = new[]
            {
                (name: GlobalConstants.AdministratorUserName, password: GlobalConstants.AdministratorPassword, role: GlobalConstants.AdministratorRoleName),
                (name: "bob@bob.com", password: "Passw0rd!", role: "Moderator"),
                (name: "abi@abi.com", password: "Company!", role: "Company"),
                (name: "nesho1978@abv.bg", password:"nesho1978", role: "Proffesional"),
                (name: "fred@fred.com", password: "Passw0rd!", role: "")
            };

            foreach ((string name, string password, string role) user in demoUsers)
            {
                AddUserIfNotExists(userManager, user);
            }

        }

        private static void AddUserIfNotExists(UserManager<ApplicationUser> userManager, (string name, string password, string role) demoUser)
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
        private static void AddRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.FindByNameAsync(roleName).Result == default)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName }).Wait();
            }
        }
    }
}
