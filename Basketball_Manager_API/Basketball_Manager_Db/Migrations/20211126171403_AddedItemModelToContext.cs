using Microsoft.EntityFrameworkCore.Migrations;

namespace Basketball_Manager_Db.Migrations
{
    public partial class AddedItemModelToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_ItemModel_ItemId",
                table: "UsersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModel",
                table: "ItemModel");

            migrationBuilder.RenameTable(
                name: "ItemModel",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersItems_ItemModels_ItemId",
                table: "UsersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModels",
                table: "ItemModels");

            migrationBuilder.RenameTable(
                name: "ItemModels",
                newName: "ItemModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemModel",
                table: "ItemModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersItems_ItemModel_ItemId",
                table: "UsersItems",
                column: "ItemId",
                principalTable: "ItemModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
