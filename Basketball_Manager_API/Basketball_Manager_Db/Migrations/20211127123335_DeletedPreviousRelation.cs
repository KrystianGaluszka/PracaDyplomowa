using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class DeletedPreviousRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerInfos_Players_PlayerId",
                table: "PlayerInfos");

            migrationBuilder.DropIndex(
                name: "IX_PlayerInfos_PlayerId",
                table: "PlayerInfos");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PlayerInfos");

            migrationBuilder.AddColumn<int>(
                name: "PlayerInfoId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                principalTable: "PlayerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerInfoId",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "PlayerInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInfos_PlayerId",
                table: "PlayerInfos",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerInfos_Players_PlayerId",
                table: "PlayerInfos",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
