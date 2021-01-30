using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.API.Data.Migrations
{
    public partial class MilkSeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ConsumeFactor", "DefaultBestBefore", "DefaultConsumeWithin", "DefaultLocationId", "Name" },
                values: new object[] { new Guid("6299ec40-a19b-4feb-9b4b-bb0c805d5dcd"), 4, new TimeSpan(7, 0, 0, 0, 0), new TimeSpan(4, 0, 0, 0, 0), new Guid("34aef97c-1b6b-4c5e-a33b-38739515de70"), "Milk (2 Pints)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6299ec40-a19b-4feb-9b4b-bb0c805d5dcd"));
        }
    }
}
