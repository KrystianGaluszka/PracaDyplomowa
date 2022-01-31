using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class sportshallToStadiumChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stadiums_SportsHallId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SportsHallId",
                table: "Users",
                newName: "StadiumId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SportsHallId",
                table: "Users",
                newName: "IX_Users_StadiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stadiums_StadiumId",
                table: "Users",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stadiums_StadiumId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StadiumId",
                table: "Users",
                newName: "SportsHallId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StadiumId",
                table: "Users",
                newName: "IX_Users_SportsHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stadiums_SportsHallId",
                table: "Users",
                column: "SportsHallId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
