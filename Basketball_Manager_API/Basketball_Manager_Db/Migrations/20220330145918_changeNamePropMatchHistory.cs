using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class changeNamePropMatchHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpponentScore",
                table: "UsersMatchesHistory",
                newName: "User2Score");

            migrationBuilder.RenameColumn(
                name: "OpponentId",
                table: "UsersMatchesHistory",
                newName: "User2Id");

            migrationBuilder.RenameColumn(
                name: "OpponentClub",
                table: "UsersMatchesHistory",
                newName: "User2Club");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User2Score",
                table: "UsersMatchesHistory",
                newName: "OpponentScore");

            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "UsersMatchesHistory",
                newName: "OpponentId");

            migrationBuilder.RenameColumn(
                name: "User2Club",
                table: "UsersMatchesHistory",
                newName: "OpponentClub");
        }
    }
}
