using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class addedTwoUserPlayerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBoosted",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "IsCaptain",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "IsInjured",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "IsOnAuction",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "IsOnBench",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "IsPlaying",
                table: "UsersPlayers");

            migrationBuilder.CreateTable(
                name: "UsersPlayersPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPlayerId = table.Column<int>(type: "int", nullable: false),
                    OnePoints = table.Column<int>(type: "int", nullable: false),
                    TwoPoints = table.Column<int>(type: "int", nullable: false),
                    ThreePoints = table.Column<int>(type: "int", nullable: false),
                    AllOnePoints = table.Column<int>(type: "int", nullable: false),
                    AllTwoPoints = table.Column<int>(type: "int", nullable: false),
                    AllThreePoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlayersPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPlayersPoints_UsersPlayers_UserPlayerId",
                        column: x => x.UserPlayerId,
                        principalTable: "UsersPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPlayerStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPlayerId = table.Column<int>(type: "int", nullable: false),
                    IsCaptain = table.Column<bool>(type: "bit", nullable: false),
                    IsOnAuction = table.Column<bool>(type: "bit", nullable: false),
                    IsPlaying = table.Column<bool>(type: "bit", nullable: false),
                    IsOnBench = table.Column<bool>(type: "bit", nullable: false),
                    IsInjured = table.Column<bool>(type: "bit", nullable: false),
                    IsBoosted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlayerStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPlayerStates_UsersPlayers_UserPlayerId",
                        column: x => x.UserPlayerId,
                        principalTable: "UsersPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlayersPoints_UserPlayerId",
                table: "UsersPlayersPoints",
                column: "UserPlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlayerStates_UserPlayerId",
                table: "UsersPlayerStates",
                column: "UserPlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPlayersPoints");

            migrationBuilder.DropTable(
                name: "UsersPlayerStates");

            migrationBuilder.AddColumn<bool>(
                name: "IsBoosted",
                table: "UsersPlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCaptain",
                table: "UsersPlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInjured",
                table: "UsersPlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnAuction",
                table: "UsersPlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnBench",
                table: "UsersPlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlaying",
                table: "UsersPlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
