using Microsoft.EntityFrameworkCore;
using RestApi.Configuration;

namespace RestApi.Models
{
    public class EmpContext: DbContext
    {
        public EmpContext()
        {
            
        }

        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {
            
        }
        
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobEfConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEfConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEfConfiguration());
            modelBuilder.ApplyConfiguration(new EmploymentEfConfiguration());
        }
    }
}