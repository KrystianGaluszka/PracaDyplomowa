using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class nameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SportsHalls_SportsHallId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMatchDetails_Users_UserId",
                table: "UsersMatchDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMatchHistory_Users_UserId",
                table: "UsersMatchHistory");

            migrationBuilder.DropTable(
                name: "SportsHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMatchHistory",
                table: "UsersMatchHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMatchDetails",
                table: "UsersMatchDetails");

            migrationBuilder.RenameTable(
                name: "UsersMatchHistory",
                newName: "UsersMatchesHistory");

            migrationBuilder.RenameTable(
                name: "UsersMatchDetails",
                newName: "UsersDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMatchHistory_UserId",
                table: "UsersMatchesHistory",
                newName: "IX_UsersMatchesHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMatchDetails_UserId",
                table: "UsersDetails",
                newName: "IX_UsersDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMatchesHistory",
                table: "UsersMatchesHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDetails",
                table: "UsersDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IncomePerViewer = table.Column<float>(type: "real", nullable: false),
                    SeatsCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stadiums_SportsHallId",
                table: "Users",
                column: "SportsHallId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDetails_Users_UserId",
                table: "UsersDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMatchesHistory_Users_UserId",
                table: "UsersMatchesHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stadiums_SportsHallId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDetails_Users_UserId",
                table: "UsersDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMatchesHistory_Users_UserId",
                table: "UsersMatchesHistory");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMatchesHistory",
                table: "UsersMatchesHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDetails",
                table: "UsersDetails");

            migrationBuilder.RenameTable(
                name: "UsersMatchesHistory",
                newName: "UsersMatchHistory");

            migrationBuilder.RenameTable(
                name: "UsersDetails",
                newName: "UsersMatchDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMatchesHistory_UserId",
                table: "UsersMatchHistory",
                newName: "IX_UsersMatchHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersDetails_UserId",
                table: "UsersMatchDetails",
                newName: "IX_UsersMatchDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMatchHistory",
                table: "UsersMatchHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMatchDetails",
                table: "UsersMatchDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SportsHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomePerViewer = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SeatsCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsHalls", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SportsHalls_SportsHallId",
                table: "Users",
                column: "SportsHallId",
                principalTable: "SportsHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMatchDetails_Users_UserId",
                table: "UsersMatchDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMatchHistory_Users_UserId",
                table: "UsersMatchHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
