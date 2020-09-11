using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class ProductLocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockedItems_Locations_LocationId",
                table: "StockedItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "StockedItems",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_StockedItems_Locations_LocationId",
                table: "StockedItems",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockedItems_Locations_LocationId",
                table: "StockedItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "StockedItems",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockedItems_Locations_LocationId",
                table: "StockedItems",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
