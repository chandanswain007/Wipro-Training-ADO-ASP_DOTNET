using Microsoft.AspNetCore.Identity;
using SecureTaskManager.Models;
using System.Security.Claims;

namespace SecureTaskManager.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Add roles if they don't exist [cite: 24]
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create an Admin user
            if (await userManager.FindByNameAsync("admin@test.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    EmailConfirmed = true
                };
                // Passwords are automatically hashed and salted by Identity [cite: 17]
                var result = await userManager.CreateAsync(adminUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create a regular user with an "edit" claim
            if (await userManager.FindByNameAsync("user@test.com") == null)
            {
                var regularUser = new ApplicationUser
                {
                    UserName = "user@test.com",
                    Email = "user@test.com",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(regularUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                    // Add a claim to this user [cite: 27]
                    await userManager.AddClaimAsync(regularUser, new Claim("CanEditTask", "true"));
                }
            }
        }
    }
}