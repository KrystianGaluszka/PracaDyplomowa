using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class addedPropMatchHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mvp",
                table: "UsersMatchesHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mvp",
                table: "UsersMatchesHistory");
        }
    }
}
