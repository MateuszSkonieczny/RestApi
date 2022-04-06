using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApi.Models;

namespace RestApi.Configuration
{
    public class EmployeeEfConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id).HasName("Employee_Id");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(40).IsRequired();
            builder.Property(e => e.Salary).IsRequired();

            builder.HasOne(e => e.IdJobNavigation)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.IdJob)
                .HasConstraintName("Employee_Job");

            var employees = new List<Employee>();
            
            employees.Add(new Employee {Id = 1, FirstName = "John", LastName = "Smith", Salary = 5000, IdJob = 1});
            employees.Add(new Employee {Id = 2, FirstName = "Adam", LastName = "Silver", Salary = 5000, IdJob = 1});
            employees.Add(new Employee {Id = 3, FirstName = "Kate", LastName = "Adams", Salary = 10000, IdJob = 2});
            employees.Add(new Employee {Id = 4, FirstName = "Josh", LastName = "Taylor", Salary = 15000, IdJob = 3});

            builder.HasData(employees);
        }
    }
}