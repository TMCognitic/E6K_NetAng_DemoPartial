using E6K_NetAng_DemoPartial.Models.Repository;
using E6K_NetAng_DemoPartial.Models.Services;
using System.Data;
using System.Data.SqlClient;

namespace E6K_NetAng_DemoPartial.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IPaysRepository, PaysService>();
            builder.Services.AddScoped<IVilleRepository, VilleService>();


            var app = builder.Build();

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
}