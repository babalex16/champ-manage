using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class ChangeMatchWinner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_WinnerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "Matches",
                newName: "IsParticipant1Winner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsParticipant1Winner",
                table: "Matches",
                newName: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
