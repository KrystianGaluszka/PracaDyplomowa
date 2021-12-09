using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class changedAuctiontoOneToOneWithUsersPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_UsersPlayers_UsersPlayerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_UsersPlayerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "UsersPlayerId",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "UserPlayerId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_UserPlayerId",
                table: "Auctions",
                column: "UserPlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_UsersPlayers_UserPlayerId",
                table: "Auctions",
                column: "UserPlayerId",
                principalTable: "UsersPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_UsersPlayers_UserPlayerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_UserPlayerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "UserPlayerId",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "UsersPlayerId",
                table: "Auctions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_UsersPlayerId",
                table: "Auctions",
                column: "UsersPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_UsersPlayers_UsersPlayerId",
                table: "Auctions",
                column: "UsersPlayerId",
                principalTable: "UsersPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
