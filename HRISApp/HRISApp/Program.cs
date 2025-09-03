using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HRISApp.Data;
using Repos;
using Repos.Repos;
using Services;
using Models;
using HRISApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var con = builder.Configuration.GetConnectionString("RepoContext") ?? throw new InvalidOperationException("Connection string 'RepoContext' not found.");
builder.Services.AddDbContext<RepoContext>(options =>
    options.UseSqlServer(con));
builder.Services.AddScoped<IDept, Dept>();
builder.Services.AddScoped<DepartmentService, DepartmentService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IRepogeneric<Department>, Repogeneric<Department>>();
builder.Services.AddScoped<IRepogeneric<Employee>, Repogeneric<Employee>>();
builder.Services.AddScoped<IServiceInterface<Department>, ServiceClass<Department>>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var app = builder.Build();
//async Task CreateRolesAsync(IApplicationBuilder app)
//{
//    using var scope = app.ApplicationServices.CreateScope();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//    string[] roleNames = { "Admin", "Manager", "User" };

//    foreach (var roleName in roleNames)
//    {
//        if (!await roleManager.RoleExistsAsync(roleName))
//        {
//            await roleManager.CreateAsync(new IdentityRole(roleName));
//        }
//    }
//}

//await CreateRolesAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
