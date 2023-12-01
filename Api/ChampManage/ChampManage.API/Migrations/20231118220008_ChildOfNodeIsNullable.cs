using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class ChildOfNodeIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Matches_RightChildId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "RightChildId",
                table: "Matches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Matches_RightChildId",
                table: "Matches",
                column: "RightChildId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Matches_RightChildId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "RightChildId",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Matches_RightChildId",
                table: "Matches",
                column: "RightChildId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
