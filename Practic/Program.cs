using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Practic.Data;
using Practic.Data.Interfaces;
using Practic.Data.Models;
using Practic.Data.Repository;
using System.Security.Claims;

internal class Program
{
    private static IConfigurationRoot _confString;
    public Program(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
    {
        //_confString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        //_serviceProvider = serviceProvider;
    }
    private static void Main(string[] args)
    {
        //AppDBContent appDBContent = new AppDBContent();
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(@"Server=DESKTOP-CC87VPA;Database=Diplom;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"))
            .AddIdentity<ApplicationUser,ApplicationRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
                config.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppDBContent>();
        builder.Services.AddTransient<IAllAims, AimRepository>();
        builder.Services.AddTransient<IAimCategory, CategoryRepository>();
        builder.Services.AddTransient<IAllCompilers, CompilerRepository>();
        builder.Services.ConfigureApplicationCookie(config =>
        {
            config.LoginPath = "/Admin/Login";
            config.AccessDeniedPath = "/Home/AccessDenied";
        });
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Administrator", build =>
            {
                build.RequireClaim(ClaimTypes.Role, "Administrator");
            });
            options.AddPolicy("User", build =>
            {
                build.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "User")
                || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
            });
        });
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped(new_scope => AimMaker.GetAimMaker(new_scope));
        builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
        builder.Services.AddMemoryCache();
        builder.Services.AddSession();
        var app = builder.Build();
        app.UseDeveloperExceptionPage();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseSession();
        app.UseStatusCodePages();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMvc(routes =>
        {
            routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            routes.MapRoute("categoryFilter", "Aim/{action}/{category?}",new {Controller = "Aim", action="List"});
        });
        using (var scope = app.Services.CreateScope())
        {
            AppDBContent appDBContent = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            //DBObjects.Initial(appDBContent);
        }
        app.Run();
    }
}