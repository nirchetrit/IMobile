using Microsoft.EntityFrameworkCore.Migrations;

namespace IMobile.Migrations
{
    public partial class add_AddCartCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedToCartCounter",
                table: "Device",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedToCartCounter",
                table: "Device");
        }
    }
}
