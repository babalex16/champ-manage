using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class addingRoundsToMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Round",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Round",
                table: "Matches");

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "Description", "EventDateTime", "Location", "OrganizerId", "RegistrationDeadline", "RegistrationFee", "Title" },
                values: new object[] { 1, "Description of Championship 1", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Location 1", 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, "Championship 1" });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "Description", "EventDateTime", "Location", "OrganizerId", "RegistrationDeadline", "RegistrationFee", "Title" },
                values: new object[] { 2, "Description of Championship 2", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Location 2", 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.00m, "Championship 2" });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "Description", "EventDateTime", "Location", "OrganizerId", "RegistrationDeadline", "RegistrationFee", "Title" },
                values: new object[] { 3, "Description of Championship 3", new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Location 3", 3, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.00m, "Championship 3" });
        }
    }
}
