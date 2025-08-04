using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMvcProject.Data;
using SalesMvcProject.Services;

namespace SalesMvcProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var connectionString = builder.Configuration.GetConnectionString("SalesMvcProjectContext");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        
        builder.Services.AddDbContext<SalesMvcProjectContext>(options => 
                options.UseMySql(connectionString, serverVersion));

        builder.Services.AddScoped<SeedingService>();
        builder.Services.AddScoped<SellerService>();
        builder.Services.AddScoped<DepartmentService>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        var enUS = new CultureInfo("en-US");
        var localizationOptions = new RequestLocalizationOptions()
        {
            DefaultRequestCulture = new RequestCulture(enUS),
            SupportedCultures = new List<CultureInfo>{enUS},
            SupportedUICultures = new List<CultureInfo>{enUS}
        };
        app.UseRequestLocalization(localizationOptions);
        
        if (app.Environment.IsDevelopment())
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<SeedingService>();
            seeder.Seed();
        }
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
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

        app.Run();
    }
}