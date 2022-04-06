﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApi.Models;

namespace RestApi.Migrations
{
    [DbContext(typeof(EmpContext))]
    partial class EmpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestApi.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id")
                        .HasName("Department_Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Main St",
                            Name = "Back End"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Second St",
                            Name = "Front End"
                        });
                });

            modelBuilder.Entity("RestApi.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdJob")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Employee_Id");

                    b.HasIndex("IdJob");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            IdJob = 1,
                            LastName = "Smith",
                            Salary = 5000
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Adam",
                            IdJob = 1,
                            LastName = "Silver",
                            Salary = 5000
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Kate",
                            IdJob = 2,
                            LastName = "Adams",
                            Salary = 10000
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Josh",
                            IdJob = 3,
                            LastName = "Taylor",
                            Salary = 15000
                        });
                });

            modelBuilder.Entity("RestApi.Models.Employment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DismissalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("Employment_Id");

                    b.HasIndex("DeptId");

                    b.HasIndex("EmpId");

                    b.ToTable("Employment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeptId = 1,
                            EmpId = 1,
                            EmploymentDate = new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 2,
                            DeptId = 2,
                            DismissalDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmpId = 2,
                            EmploymentDate = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            DeptId = 2,
                            EmpId = 2,
                            EmploymentDate = new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 4,
                            DeptId = 1,
                            EmpId = 3,
                            EmploymentDate = new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 5,
                            DeptId = 2,
                            DismissalDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmpId = 4,
                            EmploymentDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("RestApi.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id")
                        .HasName("Job_pk");

                    b.ToTable("Job");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Junior Developer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mid Developer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Senior Developer"
                        });
                });

            modelBuilder.Entity("RestApi.Models.Employee", b =>
                {
                    b.HasOne("RestApi.Models.Job", "IdJobNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("IdJob")
                        .HasConstraintName("Employee_Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJobNavigation");
                });

            modelBuilder.Entity("RestApi.Models.Employment", b =>
                {
                    b.HasOne("RestApi.Models.Department", "IdDepartmentNavigation")
                        .WithMany("Employments")
                        .HasForeignKey("DeptId")
                        .HasConstraintName("Department_Employment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestApi.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Employments")
                        .HasForeignKey("EmpId")
                        .HasConstraintName("Employee_Employment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdDepartmentNavigation");

                    b.Navigation("IdEmployeeNavigation");
                });

            modelBuilder.Entity("RestApi.Models.Department", b =>
                {
                    b.Navigation("Employments");
                });

            modelBuilder.Entity("RestApi.Models.Employee", b =>
                {
                    b.Navigation("Employments");
                });

            modelBuilder.Entity("RestApi.Models.Job", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
