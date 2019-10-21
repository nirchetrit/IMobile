using Microsoft.EntityFrameworkCore.Migrations;

namespace IMobile.Migrations
{
    public partial class add_page_counter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCounter",
                table: "Device",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCounter",
                table: "Device");
        }
    }
}
