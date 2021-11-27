using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class minorFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersPlayers_Players_PlayerModelId",
                table: "UsersPlayers");

            migrationBuilder.DropIndex(
                name: "IX_UsersPlayers_PlayerModelId",
                table: "UsersPlayers");

            migrationBuilder.DropColumn(
                name: "PlayerModelId",
                table: "UsersPlayers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "UsersPlayers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlayers_PlayerId",
                table: "UsersPlayers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPlayers_Players_PlayerId",
                table: "UsersPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersPlayers_Players_PlayerId",
                table: "UsersPlayers");

            migrationBuilder.DropIndex(
                name: "IX_UsersPlayers_PlayerId",
                table: "UsersPlayers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "UsersPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerModelId",
                table: "UsersPlayers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlayers_PlayerModelId",
                table: "UsersPlayers",
                column: "PlayerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPlayers_Players_PlayerModelId",
                table: "UsersPlayers",
                column: "PlayerModelId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
