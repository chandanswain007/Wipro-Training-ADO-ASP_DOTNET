using Microsoft.AspNetCore.Identity;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roleNames = { "Admin", "User" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminUser = new ApplicationUser
        {
            UserName = "admin",
            Email = "admin@example.com",
            FullName = "Administrator"
        };

        var result = await userManager.CreateAsync(adminUser, "Admin@123");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        var normalUser = new ApplicationUser
        {
            UserName = "user1",
            Email = "user1@example.com",
            FullName = "Regular User"
        };

        result = await userManager.CreateAsync(normalUser, "User@123");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(normalUser, "User");
        }
    }
}