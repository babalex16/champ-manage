using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class removeCategoryFromCahmpionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Championships_ChampionshipId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ChampionshipId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
