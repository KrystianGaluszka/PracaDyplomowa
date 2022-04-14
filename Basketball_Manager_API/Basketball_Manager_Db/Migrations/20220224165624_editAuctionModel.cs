using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class editAuctionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "League",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Auctions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Condition",
                table: "Auctions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Auctions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "League",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Auctions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Auctions",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
