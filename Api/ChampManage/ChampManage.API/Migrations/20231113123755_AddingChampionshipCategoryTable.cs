using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class AddingChampionshipCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Championships_ChampionshipId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "ChampionshipCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChampionshipId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionshipCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipCategories_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipCategories_CategoryId",
                table: "ChampionshipCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipCategories_ChampionshipId",
                table: "ChampionshipCategories",
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

            migrationBuilder.DropTable(
                name: "ChampionshipCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Championships_ChampionshipId",
                table: "Categories",
                column: "ChampionshipId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
