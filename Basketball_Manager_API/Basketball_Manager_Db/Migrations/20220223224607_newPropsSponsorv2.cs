using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class newPropsSponsorv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Totality",
                table: "Sponsors",
                newName: "WinPrizeTotality");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Sponsors",
                newName: "WinPrizeCount");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "WinPrizeTotality",
                table: "Sponsors",
                newName: "Totality");

            migrationBuilder.RenameColumn(
                name: "WinPrizeCount",
                table: "Sponsors",
                newName: "Count");
        }
    }
}
