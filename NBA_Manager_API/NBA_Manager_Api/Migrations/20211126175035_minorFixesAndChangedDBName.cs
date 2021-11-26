using Microsoft.EntityFrameworkCore.Migrations;

namespace NBA_Manager_Api.Migrations
{
    public partial class minorFixesAndChangedDBName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionModelId",
                table: "AuctionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_UsersPlayers_UsersPlayerModelId",
                table: "AuctionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoModelId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sponsors_SponsorModelId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SportsHalls_SportsHallModelId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_Items_ItemModelId",
                table: "UsersItems");

            migrationBuilder.RenameColumn(
                name: "ItemModelId",
                table: "UsersItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersItems_ItemModelId",
                table: "UsersItems",
                newName: "IX_UsersItems_ItemId");

            migrationBuilder.RenameColumn(
                name: "SportsHallModelId",
                table: "Users",
                newName: "SportsHallId");

            migrationBuilder.RenameColumn(
                name: "SponsorModelId",
                table: "Users",
                newName: "SponsorId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SportsHallModelId",
                table: "Users",
                newName: "IX_Users_SportsHallId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SponsorModelId",
                table: "Users",
                newName: "IX_Users_SponsorId");

            migrationBuilder.RenameColumn(
                name: "PlayerInfoModelId",
                table: "Players",
                newName: "PlayerInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PlayerInfoModelId",
                table: "Players",
                newName: "IX_Players_PlayerInfoId");

            migrationBuilder.RenameColumn(
                name: "UsersPlayerModelId",
                table: "AuctionDetails",
                newName: "UsersPlayerId");

            migrationBuilder.RenameColumn(
                name: "AuctionModelId",
                table: "AuctionDetails",
                newName: "AuctionId");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionDetails_UsersPlayerModelId",
                table: "AuctionDetails",
                newName: "IX_AuctionDetails_UsersPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionDetails_AuctionModelId",
                table: "AuctionDetails",
                newName: "IX_AuctionDetails_AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_UsersPlayers_UsersPlayerId",
                table: "AuctionDetails",
                column: "UsersPlayerId",
                principalTable: "UsersPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                principalTable: "PlayerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sponsors_SponsorId",
                table: "Users",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SportsHalls_SportsHallId",
                table: "Users",
                column: "SportsHallId",
                principalTable: "SportsHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_Items_ItemId",
                table: "UsersItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_UsersPlayers_UsersPlayerId",
                table: "AuctionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sponsors_SponsorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SportsHalls_SportsHallId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_Items_ItemId",
                table: "UsersItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "UsersItems",
                newName: "ItemModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersItems_ItemId",
                table: "UsersItems",
                newName: "IX_UsersItems_ItemModelId");

            migrationBuilder.RenameColumn(
                name: "SportsHallId",
                table: "Users",
                newName: "SportsHallModelId");

            migrationBuilder.RenameColumn(
                name: "SponsorId",
                table: "Users",
                newName: "SponsorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SportsHallId",
                table: "Users",
                newName: "IX_Users_SportsHallModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SponsorId",
                table: "Users",
                newName: "IX_Users_SponsorModelId");

            migrationBuilder.RenameColumn(
                name: "PlayerInfoId",
                table: "Players",
                newName: "PlayerInfoModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players",
                newName: "IX_Players_PlayerInfoModelId");

            migrationBuilder.RenameColumn(
                name: "UsersPlayerId",
                table: "AuctionDetails",
                newName: "UsersPlayerModelId");

            migrationBuilder.RenameColumn(
                name: "AuctionId",
                table: "AuctionDetails",
                newName: "AuctionModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionDetails_UsersPlayerId",
                table: "AuctionDetails",
                newName: "IX_AuctionDetails_UsersPlayerModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionDetails_AuctionId",
                table: "AuctionDetails",
                newName: "IX_AuctionDetails_AuctionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionModelId",
                table: "AuctionDetails",
                column: "AuctionModelId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_UsersPlayers_UsersPlayerModelId",
                table: "AuctionDetails",
                column: "UsersPlayerModelId",
                principalTable: "UsersPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoModelId",
                table: "Players",
                column: "PlayerInfoModelId",
                principalTable: "PlayerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sponsors_SponsorModelId",
                table: "Users",
                column: "SponsorModelId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SportsHalls_SportsHallModelId",
                table: "Users",
                column: "SportsHallModelId",
                principalTable: "SportsHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_Items_ItemModelId",
                table: "UsersItems",
                column: "ItemModelId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
