using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class RemovedUnnecessaryIdVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_UsersItems_Items_ItemId",
                table: "UsersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPlayers_Players_PlayerId",
                table: "UsersPlayers");

            migrationBuilder.DropIndex(
                name: "IX_UsersPlayers_PlayerId",
                table: "UsersPlayers");

            migrationBuilder.DropIndex(
                name: "IX_UsersItems_ItemId",
                table: "UsersItems");

            migrationBuilder.DropIndex(
                name: "IX_Users_SponsorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_AuctionId",
                table: "AuctionDetails");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_UsersPlayerId",
                table: "AuctionDetails");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "UsersItems");

            migrationBuilder.DropColumn(
                name: "SponsorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlayerInfoId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "AuctionDetails");

            migrationBuilder.DropColumn(
                name: "UsersPlayerId",
                table: "AuctionDetails");

            migrationBuilder.AddColumn<int>(
                name: "PlayerModelId",
                table: "UsersPlayers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemModelId",
                table: "UsersItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SponsorModelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerInfoModelId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuctionModelId",
                table: "AuctionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersPlayerModelId",
                table: "AuctionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlayers_PlayerModelId",
                table: "UsersPlayers",
                column: "PlayerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersItems_ItemModelId",
                table: "UsersItems",
                column: "ItemModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SponsorModelId",
                table: "Users",
                column: "SponsorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerInfoModelId",
                table: "Players",
                column: "PlayerInfoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_AuctionModelId",
                table: "AuctionDetails",
                column: "AuctionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_UsersPlayerModelId",
                table: "AuctionDetails",
                column: "UsersPlayerModelId");

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
                name: "FK_UsersItems_Items_ItemModelId",
                table: "UsersItems",
                column: "ItemModelId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPlayers_Players_PlayerModelId",
                table: "UsersPlayers",
                column: "PlayerModelId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_UsersItems_Items_ItemModelId",
                table: "UsersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPlayers_Players_PlayerModelId",
                table: "UsersPlayers");

            migrationBuilder.DropIndex(
                name: "IX_UsersPlayers_PlayerModelId",
                table: "UsersPlayers");

            migrationBuilder.DropIndex(
                name: "IX_UsersItems_ItemModelId",
                table: "UsersItems");

            migrationBuilder.DropIndex(
                name: "IX_Users_SponsorModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerInfoModelId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_AuctionModelId",
                table: "AuctionDetails");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_UsersPlayerModelId",
                table: "AuctionDetails");

            migrationBuilder.DropColumn(
                name: "PlayerModelId",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "ItemModelId",
                table: "UsersItems");

            migrationBuilder.DropColumn(
                name: "SponsorModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlayerInfoModelId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AuctionModelId",
                table: "AuctionDetails");

            migrationBuilder.DropColumn(
                name: "UsersPlayerModelId",
                table: "AuctionDetails");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "UsersItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SponsorId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerInfoId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "AuctionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersPlayerId",
                table: "AuctionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlayers_PlayerId",
                table: "UsersPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersItems_ItemId",
                table: "UsersItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SponsorId",
                table: "Users",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_UsersPlayerId",
                table: "AuctionDetails",
                column: "UsersPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_UsersPlayers_UsersPlayerId",
                table: "AuctionDetails",
                column: "UsersPlayerId",
                principalTable: "UsersPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                principalTable: "PlayerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sponsors_SponsorId",
                table: "Users",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_Items_ItemId",
                table: "UsersItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPlayers_Players_PlayerId",
                table: "UsersPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
