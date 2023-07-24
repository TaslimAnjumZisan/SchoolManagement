using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManagement.Data;
using SchoolManagement.Manager.ManagerImplementation;
using SchoolManagement.Manager.ManagerInterface;
using SchoolManagement.Models;
using SchoolManagement.Repository.RepositoryImplementation;
using SchoolManagement.Repository.RepositoryInterface;

namespace SchoolManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<SchoolManagementDbContext>(Options=>Options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                
                ));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IStudentsManager, StudentManager>();
            builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
            builder.Services.AddScoped<ITeachersManager, TeacherManager>();
            builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();
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