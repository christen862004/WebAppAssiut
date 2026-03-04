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
            //custom srevise  need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRespoitory>();
            builder.Services.AddScoped<IDepartmentRspository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();

			var app = builder.Build();

            // Configure the HTTP request pipeline. middleware Day8
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

            app.Run();
        }
    }
}
