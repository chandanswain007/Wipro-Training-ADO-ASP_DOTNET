using Microsoft.AspNetCore.Identity;

namespace BookstoreApp.Data
{
    public static class DbSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Add roles [cite: 22]
            string[] roleNames = { "Admin", "Customer" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Add a default admin user [cite: 22]
            var adminUser = await userManager.FindByEmailAsync("admin@bookstore.com");
            if (adminUser == null)
            {
                var newAdmin = new IdentityUser()
                {
                    UserName = "admin@bookstore.com",
                    Email = "admin@bookstore.com",
                    EmailConfirmed = true,
                };
                // IMPORTANT: Use a strong password from user secrets in a real app
                var result = await userManager.CreateAsync(newAdmin, "Admin!123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}