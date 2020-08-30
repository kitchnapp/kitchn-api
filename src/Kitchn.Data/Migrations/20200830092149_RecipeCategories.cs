using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class RecipeCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RecipeCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name", "RecipeCategoryId" },
                values: new object[] { new Guid("198a4027-b147-4c84-a179-774a98852053"), "Dinner", null });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name", "RecipeCategoryId" },
                values: new object[] { new Guid("ea5d7b4d-29f9-4b5a-aa0b-5324ca937712"), "Lunch", null });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name", "RecipeCategoryId" },
                values: new object[] { new Guid("9aa4eec1-502c-49ae-adc0-8e9cca5250e0"), "Breakfast", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");
        }
    }
}
