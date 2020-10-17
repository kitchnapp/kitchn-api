using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class ProductMeasurements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMeasurements");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupMeasurementId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IndividualMeasurementId",
                table: "Products",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "MultipleName", "Name" },
                values: new object[] { new Guid("3afacf1b-d116-4622-a188-d0c36918efa9"), null, "Tablet" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupMeasurementId",
                table: "Products",
                column: "GroupMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IndividualMeasurementId",
                table: "Products",
                column: "IndividualMeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Measurements_GroupMeasurementId",
                table: "Products",
                column: "GroupMeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Measurements_IndividualMeasurementId",
                table: "Products",
                column: "IndividualMeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Measurements_GroupMeasurementId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Measurements_IndividualMeasurementId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GroupMeasurementId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IndividualMeasurementId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: new Guid("3afacf1b-d116-4622-a188-d0c36918efa9"));

            migrationBuilder.DropColumn(
                name: "GroupMeasurementId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IndividualMeasurementId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductMeasurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Factor = table.Column<int>(type: "integer", nullable: true),
                    GroupMeasurementId = table.Column<Guid>(type: "uuid", nullable: true),
                    IndividualMeasurementId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasurements", x => x.Id);
                });
        }
    }
}
