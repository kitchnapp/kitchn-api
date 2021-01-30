using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.API.Data.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Chores",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Title = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Chores", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Locations",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Locations", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Measurements",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true),
					MultipleName = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Measurements", x => x.Id);
				});

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

			migrationBuilder.CreateTable(
				name: "Recipes",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					Rating = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Recipes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true),
					DefaultLocationId = table.Column<Guid>(nullable: true),
					DefaultConsumeWithinDays = table.Column<TimeSpan>(nullable: true),
					DefaultBestBeforeDateDifference = table.Column<TimeSpan>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
					table.ForeignKey(
						name: "FK_Products_Locations_DefaultLocationId",
						column: x => x.DefaultLocationId,
						principalTable: "Locations",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "MeasurementConversions",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					FromMeasurementId = table.Column<Guid>(nullable: false),
					ToMeasurementId = table.Column<Guid>(nullable: false),
					Factor = table.Column<decimal>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MeasurementConversions", x => x.Id);
					table.ForeignKey(
						name: "FK_MeasurementConversions_Measurements_FromMeasurementId",
						column: x => x.FromMeasurementId,
						principalTable: "Measurements",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MeasurementConversions_Measurements_ToMeasurementId",
						column: x => x.ToMeasurementId,
						principalTable: "Measurements",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
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

			migrationBuilder.CreateTable(
				name: "StockedItems",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					ProductId = table.Column<Guid>(nullable: false),
					LocationId = table.Column<Guid>(nullable: false),
					ExpiryDate = table.Column<DateTime>(nullable: true),
					OpenedDate = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StockedItems", x => x.Id);
					table.ForeignKey(
						name: "FK_StockedItems_Locations_LocationId",
						column: x => x.LocationId,
						principalTable: "Locations",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_StockedItems_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Chores",
				columns: new[] { "Id", "Description", "Title" },
				values: new object[,]
				{
					{ new Guid("5b7ee657-1ffb-4d78-b6ef-a9f2c1506f8b"), null, "Make Bed" },
					{ new Guid("d99e4d54-934e-47ea-b5ec-135eb59f83ae"), null, "Clean Oven" },
					{ new Guid("38da484f-6d6d-4a2e-afc3-5f55f1a282a0"), null, "Empty Bins" }
				});

			migrationBuilder.InsertData(
				table: "Locations",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("34aef97c-1b6b-4c5e-a33b-38739515de70"), "Refrigerator" },
					{ new Guid("c289df2f-05af-4c9f-986e-6ce4ca304e5f"), "Freezer" },
					{ new Guid("c8154b38-0004-4930-bcf7-18365bd541b1"), "Cupboard" },
					{ new Guid("d9963f65-ef83-4659-b8a1-fce5a445012a"), "Spice Rack" }
				});

			migrationBuilder.InsertData(
				table: "Measurements",
				columns: new[] { "Id", "MultipleName", "Name" },
				values: new object[,]
				{
					{ new Guid("988c6634-beec-4e86-94f3-0970cc64ae35"), null, "Litres" },
					{ new Guid("6adb2348-5305-45b0-a275-6f8bfa1e3131"), null, "Millilitres" },
					{ new Guid("56c60917-f902-4657-9cc7-81eabb1315ae"), null, "Bottle" },
					{ new Guid("a3a2049c-1f95-4d37-abaa-5122b3e88be4"), null, "Slice" },
					{ new Guid("d38c4b90-dddf-4c0c-9369-4cc1bc474690"), null, "Kilogram" },
					{ new Guid("3ecc9b2c-caf5-4bab-984d-bdd8ba0082ea"), null, "Gram" },
					{ new Guid("25831fc7-be30-4676-8a07-cccf2d7c576b"), null, "Rasher" }
				});

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "DefaultBestBeforeDateDifference", "DefaultConsumeWithinDays", "DefaultLocationId", "Name" },
				values: new object[,]
				{
					{ new Guid("07e8aeac-8ab2-489c-a1e4-2846ef9fc680"), null, null, null, "Table Salt" },
					{ new Guid("31b912cc-b3e1-48da-a5f3-a402c56ecd25"), null, null, null, "Black Pepper" }
				});

			migrationBuilder.InsertData(
				table: "RecipeCategories",
				columns: new[] { "Id", "Name", "RecipeCategoryId" },
				values: new object[,]
				{
					{ new Guid("ea5d7b4d-29f9-4b5a-aa0b-5324ca937712"), "Lunch", null },
					{ new Guid("198a4027-b147-4c84-a179-774a98852053"), "Dinner", null },
					{ new Guid("9aa4eec1-502c-49ae-adc0-8e9cca5250e0"), "Breakfast", null }
				});

			migrationBuilder.InsertData(
				table: "MeasurementConversions",
				columns: new[] { "Id", "Factor", "FromMeasurementId", "ToMeasurementId" },
				values: new object[,]
				{
					{ new Guid("a743c8f6-f33d-435f-b186-6c00ecaf66f6"), 1000m, new Guid("3ecc9b2c-caf5-4bab-984d-bdd8ba0082ea"), new Guid("d38c4b90-dddf-4c0c-9369-4cc1bc474690") },
					{ new Guid("8734caa2-d576-4644-a5fa-6cc4b783c0b3"), 1000m, new Guid("6adb2348-5305-45b0-a275-6f8bfa1e3131"), new Guid("988c6634-beec-4e86-94f3-0970cc64ae35") }
				});

			migrationBuilder.CreateIndex(
				name: "IX_MeasurementConversions_FromMeasurementId",
				table: "MeasurementConversions",
				column: "FromMeasurementId");

			migrationBuilder.CreateIndex(
				name: "IX_MeasurementConversions_ToMeasurementId",
				table: "MeasurementConversions",
				column: "ToMeasurementId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_DefaultLocationId",
				table: "Products",
				column: "DefaultLocationId");

			migrationBuilder.CreateIndex(
				name: "IX_RecipeCategoryRecipe_RecipeCategoryId",
				table: "RecipeCategoryRecipe",
				column: "RecipeCategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_RecipeInstructions_RecipeId",
				table: "RecipeInstructions",
				column: "RecipeId");

			migrationBuilder.CreateIndex(
				name: "IX_StockedItems_LocationId",
				table: "StockedItems",
				column: "LocationId");

			migrationBuilder.CreateIndex(
				name: "IX_StockedItems_ProductId",
				table: "StockedItems",
				column: "ProductId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Chores");

			migrationBuilder.DropTable(
				name: "MeasurementConversions");

			migrationBuilder.DropTable(
				name: "ProductMeasurements");

			migrationBuilder.DropTable(
				name: "RecipeCategoryRecipe");

			migrationBuilder.DropTable(
				name: "RecipeInstructions");

			migrationBuilder.DropTable(
				name: "StockedItems");

			migrationBuilder.DropTable(
				name: "Measurements");

			migrationBuilder.DropTable(
				name: "RecipeCategories");

			migrationBuilder.DropTable(
				name: "Recipes");

			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "Locations");
		}
	}
}
