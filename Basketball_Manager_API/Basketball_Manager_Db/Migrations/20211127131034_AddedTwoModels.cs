using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class AddedTwoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RankPoints",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UsersMatchDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RankPoints = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    MatchesWon = table.Column<int>(type: "int", nullable: false),
                    MatchesDrawn = table.Column<int>(type: "int", nullable: false),
                    MatchesLost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMatchDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersMatchDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersMatchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserClub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpponentClub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserScore = table.Column<int>(type: "int", nullable: false),
                    OpponentScore = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMatchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersMatchHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMatchDetails_UserId",
                table: "UsersMatchDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersMatchHistory_UserId",
                table: "UsersMatchHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersMatchDetails");

            migrationBuilder.DropTable(
                name: "UsersMatchHistory");

            migrationBuilder.AddColumn<int>(
                name: "RankPoints",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
