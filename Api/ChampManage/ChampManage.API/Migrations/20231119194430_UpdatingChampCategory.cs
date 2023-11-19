using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class UpdatingChampCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_ChampionshipCategoryId",
                table: "Matches");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionshipCategoryId",
                table: "Matches",
                column: "ChampionshipCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_ChampionshipCategoryId",
                table: "Matches");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionshipCategoryId",
                table: "Matches",
                column: "ChampionshipCategoryId",
                unique: true);
        }
    }
}
