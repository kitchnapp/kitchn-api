using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductMeasurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndividualMeasurementId = table.Column<Guid>(nullable: false),
                    GroupMeasurementId = table.Column<Guid>(nullable: true),
                    Factor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategoryRecipe",
                columns: table => new
                {
                    RecipeCategoryId = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategoryRecipe", x => new { x.RecipeId, x.RecipeCategoryId });
                    table.ForeignKey(
                        name: "FK_RecipeCategoryRecipe_RecipeCategories_RecipeCategoryId",
                        column: x => x.RecipeCategoryId,
                        principalTable: "RecipeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategoryRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeInstructions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Instruction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeInstructions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockedItems_LocationId",
                table: "StockedItems",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockedItems_ProductId",
                table: "StockedItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DefaultLocationId",
                table: "Products",
                column: "DefaultLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementConversions_FromMeasurementId",
                table: "MeasurementConversions",
                column: "FromMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementConversions_ToMeasurementId",
                table: "MeasurementConversions",
                column: "ToMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategoryRecipe_RecipeCategoryId",
                table: "RecipeCategoryRecipe",
                column: "RecipeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInstructions_RecipeId",
                table: "RecipeInstructions",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementConversions_Measurements_FromMeasurementId",
                table: "MeasurementConversions",
                column: "FromMeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementConversions_Measurements_ToMeasurementId",
                table: "MeasurementConversions",
                column: "ToMeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Locations_DefaultLocationId",
                table: "Products",
                column: "DefaultLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockedItems_Locations_LocationId",
                table: "StockedItems",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockedItems_Products_ProductId",
                table: "StockedItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementConversions_Measurements_FromMeasurementId",
                table: "MeasurementConversions");

            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementConversions_Measurements_ToMeasurementId",
                table: "MeasurementConversions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Locations_DefaultLocationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StockedItems_Locations_LocationId",
                table: "StockedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockedItems_Products_ProductId",
                table: "StockedItems");

            migrationBuilder.DropTable(
                name: "ProductMeasurements");

            migrationBuilder.DropTable(
                name: "RecipeCategoryRecipe");

            migrationBuilder.DropTable(
                name: "RecipeInstructions");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_StockedItems_LocationId",
                table: "StockedItems");

            migrationBuilder.DropIndex(
                name: "IX_StockedItems_ProductId",
                table: "StockedItems");

            migrationBuilder.DropIndex(
                name: "IX_Products_DefaultLocationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementConversions_FromMeasurementId",
                table: "MeasurementConversions");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementConversions_ToMeasurementId",
                table: "MeasurementConversions");
        }
    }
}
