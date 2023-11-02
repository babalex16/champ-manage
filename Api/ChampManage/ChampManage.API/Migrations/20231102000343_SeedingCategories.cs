using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class SeedingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 1, 0, 2, 5, 21, 4, "Pee Wee 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 2, 0, 2, 5, 200, 4, "Pee Wee 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 3, 0, 3, 7, 21, 6, "Pee Wee 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 4, 0, 3, 7, 24, 6, "Pee Wee 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 5, 0, 3, 7, 27, 6, "Pee Wee 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 6, 0, 3, 7, 30, 6, "Pee Wee 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 7, 0, 3, 7, 200, 6, "Pee Wee 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 8, 0, 3, 9, 24, 8, "Junior 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 9, 0, 3, 9, 27, 8, "Junior 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 10, 0, 3, 9, 30, 8, "Junior 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 11, 0, 3, 9, 34, 8, "Junior 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 12, 0, 3, 9, 38, 8, "Junior 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 13, 0, 3, 9, 42, 8, "Junior 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Belt", "FightTimeMinutes", "MaxAge", "MaxWeight", "MinAge", "Name" },
                values: new object[] { 14, 0, 3, 9, 200, 8, "Junior 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
