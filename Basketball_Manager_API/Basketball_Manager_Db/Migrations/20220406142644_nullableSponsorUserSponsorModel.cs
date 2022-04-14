using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class nullableSponsorUserSponsorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSponsors_Sponsors_SponsorId",
                table: "UsersSponsors");

            migrationBuilder.AlterColumn<int>(
                name: "SponsorId",
                table: "UsersSponsors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSponsors_Sponsors_SponsorId",
                table: "UsersSponsors",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSponsors_Sponsors_SponsorId",
                table: "UsersSponsors");

            migrationBuilder.AlterColumn<int>(
                name: "SponsorId",
                table: "UsersSponsors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSponsors_Sponsors_SponsorId",
                table: "UsersSponsors",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
