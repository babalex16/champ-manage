using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChampManage.API.Migrations
{
    public partial class ChampManageDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TeamName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Belt = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RegistrationFee = table.Column<decimal>(type: "TEXT", nullable: false),
                    RegistrationDeadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championships_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipUser",
                columns: table => new
                {
                    ParticipantsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteredChampionshipsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipUser", x => new { x.ParticipantsId, x.RegisteredChampionshipsId });
                    table.ForeignKey(
                        name: "FK_ChampionshipUser_Championships_RegisteredChampionshipsId",
                        column: x => x.RegisteredChampionshipsId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipUser_Users_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championships_OrganizerId",
                table: "Championships",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipUser_RegisteredChampionshipsId",
                table: "ChampionshipUser",
                column: "RegisteredChampionshipsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipUser");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
