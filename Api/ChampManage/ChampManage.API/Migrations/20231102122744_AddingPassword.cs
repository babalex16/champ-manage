using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class AddingPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ChampionshipId",
                table: "Categories",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Championships_ChampionshipId",
                table: "Categories",
                column: "ChampionshipId",
                principalTable: "Championships",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Championships_ChampionshipId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ChampionshipId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "Categories");

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
        }
    }
}
