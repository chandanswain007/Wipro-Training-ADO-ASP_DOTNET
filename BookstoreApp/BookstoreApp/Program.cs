using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Data;
using BookstoreApp.Repositories;
using BookstoreApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// 1. Database and Identity Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Enable roles
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 2. Dependency Injection for Repository Pattern [cite: 47]
builder.Services.AddScoped<IBookRepository, BookRepository>();

// 3. MVC, Razor Pages, and Global Filter Configuration 
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>(); // Apply global filter for error handling
});
// Add this after builder.Services.AddRazorPages(); in Program.cs
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/AdminBooks", "Admin"); // Restrict folder to Admin role
});

// 4. Session Management Configuration [cite: 32, 61]
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession(); // Enable session middleware

// 5. Routing Configuration [cite: 60]
app.MapControllerRoute(
    name: "bookDetailsByIsbn", // Custom route for accessing book details by ISBN [cite: 46]
    pattern: "book/{isbn}",
    defaults: new { controller = "Books", action = "DetailsByIsbn" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Seed the database with roles and an admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbSeeder.Initialize(services);
}

app.Run();