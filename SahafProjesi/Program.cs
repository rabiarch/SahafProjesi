using Microsoft.EntityFrameworkCore;
using SahafProjesi.Data;

namespace SahafProjesi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<SahafDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
            builder.Services.AddSession(x=>x.IdleTimeout = TimeSpan.FromSeconds(360));
            builder.Services.AddHttpContextAccessor();

            //************//
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Sessionlar? kullanmas? için bunu biz ekliyoruz burada.
            app.UseSession();

            app.Run();
        }
    }
}
