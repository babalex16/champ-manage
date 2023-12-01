using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Belt", "Birthdate", "Email", "FirstName", "Gender", "LastName", "Phone", "TeamName", "UserType", "Weight" },
                values: new object[] { 1, 0, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", "John", 0, "Doe", "123-456-7890", "Team A", 0, 80 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Belt", "Birthdate", "Email", "FirstName", "Gender", "LastName", "Phone", "TeamName", "UserType", "Weight" },
                values: new object[] { 2, 1, new DateTime(1995, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", "Jane", 1, "Smith", "987-654-3210", "Team B", 0, 50 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Belt", "Birthdate", "Email", "FirstName", "Gender", "LastName", "Phone", "TeamName", "UserType", "Weight" },
                values: new object[] { 3, 2, new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", "Bob", 0, "Johnson", "555-123-4567", "Team C", 1, 99 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Belt", "Birthdate", "Email", "FirstName", "Gender", "LastName", "Phone", "TeamName", "UserType", "Weight" },
                values: new object[] { 4, 1, new DateTime(1998, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Alice", 1, "Johnson", "789-012-3456", "Team D", 1, 55 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Belt", "Birthdate", "Email", "FirstName", "Gender", "LastName", "Phone", "TeamName", "UserType", "Weight" },
                values: new object[] { 5, 2, new DateTime(1992, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael@example.com", "Michael", 0, "Smith", null, "Team E", 1, 78 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Belt", "Birthdate", "Email", "FirstName", "Gender", "LastName", "Phone", "TeamName", "UserType", "Weight" },
                values: new object[] { 6, 0, new DateTime(1989, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "samantha@example.com", "Samantha", 1, "Brown", null, "Team F", 1, 68 });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "DateTime", "Description", "Location", "OrganizerId", "RegistrationDeadline", "RegistrationFee", "Title" },
                values: new object[] { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Championship 1", "Location 1", 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, "Championship 1" });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "DateTime", "Description", "Location", "OrganizerId", "RegistrationDeadline", "RegistrationFee", "Title" },
                values: new object[] { 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Championship 2", "Location 2", 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.00m, "Championship 2" });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "DateTime", "Description", "Location", "OrganizerId", "RegistrationDeadline", "RegistrationFee", "Title" },
                values: new object[] { 3, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Championship 3", "Location 3", 3, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.00m, "Championship 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Championships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Championships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Championships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
