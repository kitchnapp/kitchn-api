using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class ConsumedCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumedCount",
                table: "StockedItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumedCount",
                table: "StockedItems");
        }
    }
}
