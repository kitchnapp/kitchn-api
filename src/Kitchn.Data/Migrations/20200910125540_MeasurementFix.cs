using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class MeasurementFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: new Guid("6adb2348-5305-45b0-a275-6f8bfa1e3131"),
                column: "Name",
                value: "Millilitre");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: new Guid("988c6634-beec-4e86-94f3-0970cc64ae35"),
                column: "Name",
                value: "Litre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: new Guid("6adb2348-5305-45b0-a275-6f8bfa1e3131"),
                column: "Name",
                value: "Millilitres");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: new Guid("988c6634-beec-4e86-94f3-0970cc64ae35"),
                column: "Name",
                value: "Litres");
        }
    }
}
