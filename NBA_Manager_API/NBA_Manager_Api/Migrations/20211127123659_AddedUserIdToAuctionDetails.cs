﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace NBA_Manager_Api.Migrations
{
    public partial class AddedUserIdToAuctionDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AuctionDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AuctionDetails");
        }
    }
}
