using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class newPropAuctionAndExchangepropsUserPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "League",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "UsersPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "League",
                table: "UsersPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "League",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Auctions");

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "League",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
