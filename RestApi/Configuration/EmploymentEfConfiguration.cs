using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApi.Models;

namespace RestApi.Configuration
{
    public class EmploymentEfConfiguration: IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> builder)
        {
            builder.HasKey(e => e.Id).HasName("Employment_Id");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.EmploymentDate).IsRequired();

            builder.HasOne(e => e.IdEmployeeNavigation)
                .WithMany(e => e.Employments)
                .HasForeignKey(e => e.EmpId)
                .HasConstraintName("Employee_Employment");

            builder.HasOne(e => e.IdDepartmentNavigation)
                .WithMany(e => e.Employments)
                .HasForeignKey(e => e.DeptId)
                .HasConstraintName("Department_Employment");

            var employments = new List<Employment>();
            employments.Add(new Employment {Id = 1, DeptId = 1, EmpId = 1, EmploymentDate = DateTime.Today, DismissalDate = null});
            employments.Add(new Employment {Id = 2, DeptId = 2, EmpId = 2, EmploymentDate = new DateTime(2021, 5, 2), DismissalDate = new DateTime(2022, 1, 1)});
            employments.Add(new Employment {Id = 3, DeptId = 2, EmpId = 2, EmploymentDate = DateTime.Today, DismissalDate = null});
            employments.Add(new Employment {Id = 4, DeptId = 1, EmpId = 3, EmploymentDate = DateTime.Today, DismissalDate = null});
            employments.Add(new Employment {Id = 5, DeptId = 2, EmpId = 4, EmploymentDate = new DateTime(2020, 1, 1), DismissalDate = new DateTime(2021, 1, 1)});

            builder.HasData(employments);
        }
    }
}