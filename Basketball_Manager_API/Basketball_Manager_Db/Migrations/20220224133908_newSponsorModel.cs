using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class newSponsorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sponsors_SponsorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SponsorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MatchPrizeCount",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "MatchPrizeTotality",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "TitlePrizeCount",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "TitlePrizeTotality",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "WinPrizeCount",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "WinPrizeTotality",
                table: "Sponsors");

            migrationBuilder.CreateTable(
                name: "UsersSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SponsorId = table.Column<int>(type: "int", nullable: false),
                    MatchPrizeCount = table.Column<int>(type: "int", nullable: false),
                    MatchPrizeTotality = table.Column<float>(type: "real", nullable: false),
                    WinPrizeCount = table.Column<int>(type: "int", nullable: false),
                    WinPrizeTotality = table.Column<float>(type: "real", nullable: false),
                    TitlePrizeCount = table.Column<int>(type: "int", nullable: false),
                    TitlePrizeTotality = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersSponsors_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersSponsors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersSponsors_SponsorId",
                table: "UsersSponsors",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSponsors_UserId",
                table: "UsersSponsors",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersSponsors");

            migrationBuilder.AddColumn<int>(
                name: "MatchPrizeCount",
                table: "Sponsors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MatchPrizeTotality",
                table: "Sponsors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TitlePrizeCount",
                table: "Sponsors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TitlePrizeTotality",
                table: "Sponsors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "WinPrizeCount",
                table: "Sponsors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "WinPrizeTotality",
                table: "Sponsors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SponsorId",
                table: "Users",
                column: "SponsorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sponsors_SponsorId",
                table: "Users",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id");
        }
    }
}
