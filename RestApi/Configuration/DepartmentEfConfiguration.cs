using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApi.Models;

namespace RestApi.Configuration
{
    public class DepartmentEfConfiguration: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id).HasName("Department_Id");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).HasMaxLength(40).IsRequired();
            builder.Property(e => e.Location).HasMaxLength(50).IsRequired();

            var departments = new List<Department>();
            
            departments.Add(new Department {Id = 1, Name = "Back End", Location = "Main St"});
            departments.Add(new Department {Id = 2, Name = "Front End", Location = "Second St"});

            builder.HasData(departments);
        }
    }
}