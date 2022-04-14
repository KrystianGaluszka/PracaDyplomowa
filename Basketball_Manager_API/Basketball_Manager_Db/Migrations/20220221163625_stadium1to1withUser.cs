using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class stadium1to1withUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stadiums_StadiumId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StadiumId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StadiumId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Stadiums",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_UserId",
                table: "Stadiums",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Users_UserId",
                table: "Stadiums",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Users_UserId",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Stadiums_UserId",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stadiums");

            migrationBuilder.AddColumn<int>(
                name: "StadiumId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StadiumId",
                table: "Users",
                column: "StadiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stadiums_StadiumId",
                table: "Users",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id");
        }
    }
}
