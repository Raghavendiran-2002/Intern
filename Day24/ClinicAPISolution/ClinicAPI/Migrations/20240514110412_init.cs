using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "DateOfBirth", "Experience", "Gender", "Name", "Specialization" },
                values: new object[,]
                {
                    { 101, 32, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.5f, "Male", "Pranav", "Dentist" },
                    { 102, 51, new DateTime(1954, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, "Male", "Tharun", "Sergeon" },
                    { 103, 65, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5f, "Male", "Raj", "Dentist" },
                    { 104, 73, new DateTime(1954, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 23f, "FeMale", "Tom", "Sergeon" },
                    { 105, 42, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5f, "Male", "Seyon", "Dentist" },
                    { 106, 76, new DateTime(1954, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 73f, "FeMale", "Joe", "Dermatologist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
