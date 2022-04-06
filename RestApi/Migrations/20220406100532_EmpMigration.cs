using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class EmpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Department_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Job_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    IdJob = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_Id", x => x.Id);
                    table.ForeignKey(
                        name: "Employee_Job",
                        column: x => x.IdJob,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DismissalDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employment_Id", x => x.Id);
                    table.ForeignKey(
                        name: "Department_Employment",
                        column: x => x.DeptId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Employee_Employment",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Main St", "Back End" },
                    { 2, "Second St", "Front End" }
                });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Junior Developer" },
                    { 2, "Mid Developer" },
                    { 3, "Senior Developer" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "IdJob", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, "John", 1, "Smith", 5000 },
                    { 2, "Adam", 1, "Silver", 5000 },
                    { 3, "Kate", 2, "Adams", 10000 },
                    { 4, "Josh", 3, "Taylor", 15000 }
                });

            migrationBuilder.InsertData(
                table: "Employment",
                columns: new[] { "Id", "DeptId", "DismissalDate", "EmpId", "EmploymentDate" },
                values: new object[,]
                {
                    { 1, 1, null, 1, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, null, 2, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 1, null, 3, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdJob",
                table: "Employee",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_Employment_DeptId",
                table: "Employment",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employment_EmpId",
                table: "Employment",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employment");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
