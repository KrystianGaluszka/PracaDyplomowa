using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class changedAuctionAndPlayersTableAndUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AuctionDetails_AuctionDetailsId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayersInfo_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "AuctionDetails");

            migrationBuilder.DropTable(
                name: "PlayersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersMatchDetails_UserId",
                table: "UsersMatchDetails");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerInfoId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "AuctionDetailsId",
                table: "Auctions",
                newName: "UsersPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Auctions_AuctionDetailsId",
                table: "Auctions",
                newName: "IX_Auctions_UsersPlayerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MatchDate",
                table: "UsersMatchHistory",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Players",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsLegend",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "League",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Players",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Bid",
                table: "Auctions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Auctions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersMatchDetails_UserId",
                table: "UsersMatchDetails",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_UsersPlayers_UsersPlayerId",
                table: "Auctions",
                column: "UsersPlayerId",
                principalTable: "UsersPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_UsersPlayers_UsersPlayerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_UsersMatchDetails_UserId",
                table: "UsersMatchDetails");

            migrationBuilder.DropColumn(
                name: "Club",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsLegend",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "League",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Bid",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "UsersPlayerId",
                table: "Auctions",
                newName: "AuctionDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Auctions_UsersPlayerId",
                table: "Auctions",
                newName: "IX_Auctions_AuctionDetailsId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MatchDate",
                table: "UsersMatchHistory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerInfoId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuctionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bid = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDetails_UsersPlayers_UsersPlayerId",
                        column: x => x.UsersPlayerId,
                        principalTable: "UsersPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Club = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: false),
                    IsLegend = table.Column<bool>(type: "bit", nullable: false),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMatchDetails_UserId",
                table: "UsersMatchDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_UsersPlayerId",
                table: "AuctionDetails",
                column: "UsersPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AuctionDetails_AuctionDetailsId",
                table: "Auctions",
                column: "AuctionDetailsId",
                principalTable: "AuctionDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayersInfo_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                principalTable: "PlayersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
