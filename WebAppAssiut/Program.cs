using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using WebAppAssiut.Filtters;
using WebAppAssiut.Repository;

namespace WebAppAssiut
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. Day7
            //built in services not need to register
            //built in services  need to register
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new ErrorHandelAttribute());//gloabla pplication scop
            //});
            builder.Services.AddControllersWithViews();
            //ITIContext ,dbcontextoptions
            builder.Services.AddDbContext<ITIContext>(optionsBuilder => { 
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                }).AddEntityFrameworkStores<ITIContext>();
            //custom srevise  need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRespoitory>();
            builder.Services.AddScoped<IDepartmentRspository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();

			var app = builder.Build();

            // Configure the HTTP request pipeline. middleware Day8
            #region Custom PipLine 
            //app.Use(async(httpcontext, nextMiddleware) => {
            //    await httpcontext.Response.WriteAsync("1- Middleware 1 \n");//<--1
            //    await nextMiddleware.Invoke();//<--2
            //    await httpcontext.Response.WriteAsync("1-1 Middleware 1-1  \n");//<--7

            //});
            //app.Use(async (httpcontext, nextMiddleware) => {
            //    await httpcontext.Response.WriteAsync("2- Middleware 2 \n");//<--3
            //    await nextMiddleware.Invoke();//<--4
            //    await httpcontext.Response.WriteAsync("2-2 Middleware 2-2 \n");//<--6

            //});
            //app.Run(async(httpcontext) =>{
            //    await httpcontext.Response.WriteAsync("3. Terminate\n");//<--5
            //});
            #endregion
            #region Built In Pipline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//Handel Re ==>WWroote

            app.UseRouting();//Employee/inex  Secutry Mapping
            
            app.UseSession();

            app.UseAuthorization();
            //naimg Convetion route
            //app.MapControllerRoute("Route1", "r1/{age:int:range(20,25)}/{name?}", new { controller="Route",action="M1"});
            //app.MapControllerRoute("Route1", "r1", new { controller="Route",action="M1"});
            //app.MapControllerRoute("Route2", "r2", new { controller = "Route", action = "M2" });
            //app.MapControllerRoute("Route1", "r/{action}", new { controller="Route",action="M1"});
            //app.MapControllerRoute("Route2", "e/{action}", new { controller = "Employee", action = "Index" });
           // app.MapControllerRoute(name:"Route1", pattern:"{controller}/{action}", new { controller = "Route", action = "M1" });


            app.MapControllerRoute( //Staff ddeclare ,execute 
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
