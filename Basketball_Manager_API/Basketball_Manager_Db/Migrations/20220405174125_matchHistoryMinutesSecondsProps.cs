using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class matchHistoryMinutesSecondsProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinutesLeft",
                table: "UsersMatchesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondsLeft",
                table: "UsersMatchesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutesLeft",
                table: "UsersMatchesHistory");

            migrationBuilder.DropColumn(
                name: "SecondsLeft",
                table: "UsersMatchesHistory");
        }
    }
}
