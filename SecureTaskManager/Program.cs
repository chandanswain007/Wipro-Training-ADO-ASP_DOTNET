using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecureTaskManager.Data;
using SecureTaskManager.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add DbContext and Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("SecureAppDb")); // Using in-memory database 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings - Hashing is handled automatically
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 2. Configure Secure Session Management [cite: 37]
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";

    // Secure cookie settings [cite: 40]
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Enforce HTTPS [cite: 42]
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15); // Session expiration [cite: 41]
    options.SlidingExpiration = true; // Resets expiration on activity [cite: 41]
});

// 3. Configure Authorization Policies for Claims [cite: 28]
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanEditTaskPolicy", policy =>
        policy.RequireClaim("CanEditTask", "true")); // [cite: 27]
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed the database with default roles and users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Enforce HTTPS
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT: Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();