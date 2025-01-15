using FinalProject_Entities.Models;
using FinalProject_Repositories;
using FinalProject_Repositories.Contexts;
using FinalProject_Repositories.Contracts;
using FinalProject_Repositories.UniteOfWork;
using FinalProject_Services;
using FinalProject_Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            builder.Services.AddDbContext<RepositoryContex>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn"),b=>b.MigrationsAssembly("FinalProject-WebApp")).UseLazyLoadingProxies();
            }); // proje ayaða kalktýðýnda repository contex oluþturacak zaten 
            builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddSingleton<Cart>();


            builder.Services.AddAutoMapper(typeof(Program));
            
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
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}