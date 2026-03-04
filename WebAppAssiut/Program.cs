using Microsoft.EntityFrameworkCore;
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
			builder.Services.AddControllersWithViews();
            //ITIContext ,dbcontextoptions
            builder.Services.AddDbContext<ITIContext>(optionsBuilder => { 
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });
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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
