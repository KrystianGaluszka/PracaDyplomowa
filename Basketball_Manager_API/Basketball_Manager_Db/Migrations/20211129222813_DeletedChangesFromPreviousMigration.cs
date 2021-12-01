using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class DeletedChangesFromPreviousMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails");

            migrationBuilder.AlterColumn<int>(
                name: "AuctionId",
                table: "AuctionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails");

            migrationBuilder.AlterColumn<int>(
                name: "AuctionId",
                table: "AuctionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Auctions_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
