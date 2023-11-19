using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class addingBinaryTreeBracketStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Championships_ChampionshipId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_Participant1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_Participant2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_WinnerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ChampionshipId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "ChampionshipId",
                table: "Matches",
                newName: "RightChildId");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Matches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Participant2Id",
                table: "Matches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Participant1Id",
                table: "Matches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipCategoryId",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeftChildId",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionshipCategoryId",
                table: "Matches",
                column: "ChampionshipCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LeftChildId",
                table: "Matches",
                column: "LeftChildId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RightChildId",
                table: "Matches",
                column: "RightChildId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ChampionshipCategories_ChampionshipCategoryId",
                table: "Matches",
                column: "ChampionshipCategoryId",
                principalTable: "ChampionshipCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Matches_LeftChildId",
                table: "Matches",
                column: "LeftChildId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Matches_RightChildId",
                table: "Matches",
                column: "RightChildId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_Participant1Id",
                table: "Matches",
                column: "Participant1Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_Participant2Id",
                table: "Matches",
                column: "Participant2Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ChampionshipCategories_ChampionshipCategoryId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Matches_LeftChildId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Matches_RightChildId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_Participant1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_Participant2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_WinnerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ChampionshipCategoryId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_LeftChildId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_RightChildId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ChampionshipCategoryId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LeftChildId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "RightChildId",
                table: "Matches",
                newName: "ChampionshipId");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Participant2Id",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Participant1Id",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionshipId",
                table: "Matches",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Championships_ChampionshipId",
                table: "Matches",
                column: "ChampionshipId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_Participant1Id",
                table: "Matches",
                column: "Participant1Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_Participant2Id",
                table: "Matches",
                column: "Participant2Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
