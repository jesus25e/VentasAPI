using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Identity.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(
        IServiceProvider serviceProvider)
        {
            using var scope =
                serviceProvider.CreateScope();

            var roleManager =
                scope.ServiceProvider
                    .GetRequiredService<
                        RoleManager<IdentityRole>>();

            var userManager =
                scope.ServiceProvider
                    .GetRequiredService<
                        UserManager<ApplicationUser>>();

            await SeedRoles(roleManager);

            await SeedAdmin(userManager);
        }

        private static async Task SeedRoles(
            RoleManager<IdentityRole> roleManager)
        {
            string[] roles =
            {
            Roles.Admin,
            Roles.Manager,
            Roles.Seller
        };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdmin(
            UserManager<ApplicationUser> userManager)
        {
            const string email =
                "admin@inventory.com";

            var admin =
                await userManager.FindByEmailAsync(email);

            if (admin != null)
                return;

            admin = new ApplicationUser
            {
                Email = email,

                UserName = email,

                FirstName = "System",

                LastName = "Administrator",

                EmailConfirmed = true
            };

            var result =
                await userManager.CreateAsync(
                    admin,
                    "Admin123*");

            if (!result.Succeeded)
                return;

            await userManager.AddToRoleAsync(
                admin,
                Roles.Admin);
        }
    }
}
