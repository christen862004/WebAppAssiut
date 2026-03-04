using Microsoft.EntityFrameworkCore;

namespace WebAppAssiut.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //compatibility
        //public ITIContext() : base()
        //{

        //}
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Ass9M26;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        /*
         * DDbMS : SQl Server
         * Server Name :.
         * Auth :
         * Database name:
         */
    }
}
