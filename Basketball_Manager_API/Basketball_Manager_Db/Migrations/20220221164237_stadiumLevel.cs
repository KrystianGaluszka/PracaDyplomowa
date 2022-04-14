﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basketball_Manager_Db.Migrations
{
    public partial class stadiumLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Stadiums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Stadiums");
        }
    }
}
