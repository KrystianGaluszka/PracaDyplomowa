using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class ItemTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_ItemModels_ItemId",
                table: "UsersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModels",
                table: "ItemModels");

            migrationBuilder.RenameTable(
                name: "ItemModels",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_Items_ItemId",
                table: "UsersItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_Items_ItemId",
                table: "UsersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "ItemModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemModels",
                table: "ItemModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_ItemModels_ItemId",
                table: "UsersItems",
                column: "ItemId",
                principalTable: "ItemModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
