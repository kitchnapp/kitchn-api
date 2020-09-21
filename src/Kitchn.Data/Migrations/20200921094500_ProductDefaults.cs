using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class ProductDefaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultBestBeforeDateDifference",
                table: "Products",
                newName: "DefaultBestBefore");

            migrationBuilder.RenameColumn(
                name: "DefaultConsumeWithinDays",
                table: "Products",
                newName: "DefaultConsumeWithin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultBestBefore",
                table: "Products",
                newName: "DefaultBestBeforeDateDifference");

            migrationBuilder.RenameColumn(
                name: "DefaultConsumeWithin",
                table: "Products",
                newName: "DefaultConsumeWithinDays");
        }
    }
}
