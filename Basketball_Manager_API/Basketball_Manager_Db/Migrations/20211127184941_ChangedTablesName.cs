using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class ChangedTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerInfos");

            migrationBuilder.CreateTable(
                name: "PlayersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Club = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    IsLegend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInfo", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayersInfo_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                principalTable: "PlayersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayersInfo_PlayerInfoId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayersInfo");

            migrationBuilder.CreateTable(
                name: "PlayerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Club = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: false),
                    IsLegend = table.Column<bool>(type: "bit", nullable: false),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerInfos_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                principalTable: "PlayerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
