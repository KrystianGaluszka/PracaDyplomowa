using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class AuctionsRealtionsReversed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_AuctionId",
                table: "AuctionDetails");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "AuctionDetails");

            migrationBuilder.AddColumn<int>(
                name: "AuctionDetailsId",
                table: "Auctions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_AuctionDetailsId",
                table: "Auctions",
                column: "AuctionDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AuctionDetails_AuctionDetailsId",
                table: "Auctions",
                column: "AuctionDetailsId",
                principalTable: "AuctionDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AuctionDetails_AuctionDetailsId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_AuctionDetailsId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "AuctionDetailsId",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "AuctionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
