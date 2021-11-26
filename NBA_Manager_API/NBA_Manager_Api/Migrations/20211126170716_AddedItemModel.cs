using Microsoft.EntityFrameworkCore.Migrations;

namespace NBA_Manager_Api.Migrations
{
    public partial class AddedItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "UsersItems");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "UsersItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "UsersItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersItems_ItemId",
                table: "UsersItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_ItemModel_ItemId",
                table: "UsersItems",
                column: "ItemId",
                principalTable: "ItemModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_ItemModel_ItemId",
                table: "UsersItems");

            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropIndex(
                name: "IX_UsersItems_ItemId",
                table: "UsersItems");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "UsersItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "UsersItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "UsersItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
