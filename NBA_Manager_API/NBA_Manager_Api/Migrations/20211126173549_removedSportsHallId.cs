using Microsoft.EntityFrameworkCore.Migrations;

namespace NBA_Manager_Api.Migrations
{
    public partial class removedSportsHallId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SportsHalls_SportsHallId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SportsHallId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SportsHallId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "SportsHallModelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SportsHallModelId",
                table: "Users",
                column: "SportsHallModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SportsHalls_SportsHallModelId",
                table: "Users",
                column: "SportsHallModelId",
                principalTable: "SportsHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SportsHalls_SportsHallModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SportsHallModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SportsHallModelId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "SportsHallId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SportsHallId",
                table: "Users",
                column: "SportsHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SportsHalls_SportsHallId",
                table: "Users",
                column: "SportsHallId",
                principalTable: "SportsHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
