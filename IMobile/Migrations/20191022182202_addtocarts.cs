﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace IMobile.Migrations
{
    public partial class addtocarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Cart",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Cart",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
