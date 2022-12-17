using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAppRepository.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationCategories = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    EmailId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Verification",
                columns: table => new
                {
                    VUserName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verification", x => x.VUserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "Verification");
        }
    }
}
