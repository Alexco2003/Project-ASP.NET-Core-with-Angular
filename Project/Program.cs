using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Helpers.Extensions;
using Project.Helpers.Seeders;
using Project.Models;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        
        var userService = scope.ServiceProvider.GetService<UserSubscriptionMoviesSeeder>();
        userService.SeedInitialUser();

        var roleService = scope.ServiceProvider.GetService<RolesSeeder>();
        roleService.SeedInitialRoles();

        var userRolesService = scope.ServiceProvider.GetService<UserRoleSeeder>();
        userRolesService.SeedInitialUserRoles();

        var reviewService = scope.ServiceProvider.GetService<UserMovie_Review_Seeder>();
        reviewService.SeedInitialUserMovie_Reviews_();
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSeeders();


builder.Services.AddDbContext<ProjectContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ProjectContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 8;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedAccount = false;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedPhoneNumber = false;
});



var app = builder.Build();


SeedData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

