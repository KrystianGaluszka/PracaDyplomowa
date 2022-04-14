using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class newPropsUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllMatchesDrawn",
                table: "UsersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AllMatchesLost",
                table: "UsersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AllMatchesPlayed",
                table: "UsersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AllMatchesWon",
                table: "UsersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastSeasonRank",
                table: "UsersDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllMatchesDrawn",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "AllMatchesLost",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "AllMatchesPlayed",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "AllMatchesWon",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "LastSeasonRank",
                table: "UsersDetails");
        }
    }
}
