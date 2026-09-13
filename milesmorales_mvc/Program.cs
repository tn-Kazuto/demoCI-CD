using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using milesmorales_mvc.Repository;
using milesmorales_mvc.Services;

namespace milesmorales_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataProtectionKeys")));

            string connectionString = builder.Configuration.GetConnectionString("milesConnect")
                ?? throw new InvalidOperationException("Connection string 'milesConnect' was not found.");
            builder.Services.AddDbContext<MilesmoralesDBContextcs>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                    sqlServerOptions.EnableRetryOnFailure()));
            builder.Services.AddScoped<IColorRepository, ColorRepository>();
            builder.Services.AddScoped<IColorService, ColorService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
