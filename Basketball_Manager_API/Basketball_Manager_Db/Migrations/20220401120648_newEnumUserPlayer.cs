using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class newEnumUserPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "BackgroundTasks",
                newName: "IsStarted");

            migrationBuilder.AddColumn<string>(
                name: "TrainingType",
                table: "UsersPlayers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User2Id",
                table: "BackgroundTasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "User2Id",
                table: "BackgroundTasks");

            migrationBuilder.RenameColumn(
                name: "IsStarted",
                table: "BackgroundTasks",
                newName: "IsDone");
        }
    }
}
