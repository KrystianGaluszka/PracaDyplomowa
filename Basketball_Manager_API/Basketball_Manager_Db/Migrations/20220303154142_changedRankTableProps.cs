using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class changedRankTableProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RankPointsLimit",
                table: "RankRequirements",
                newName: "PointsRequired");

            migrationBuilder.AddColumn<int>(
                name: "PointsLimit",
                table: "RankRequirements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsLimit",
                table: "RankRequirements");

            migrationBuilder.RenameColumn(
                name: "PointsRequired",
                table: "RankRequirements",
                newName: "RankPointsLimit");
        }
    }
}
