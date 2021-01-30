using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.API.Data.Migrations
{
    public partial class ConsumeFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumeFactor",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumeFactor",
                table: "Products");
        }
    }
}
