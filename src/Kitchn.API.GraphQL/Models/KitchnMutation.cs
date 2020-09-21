using System;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnMutation : ObjectGraphType
	{
		public KitchnMutation(KitchnDbContext dbContext, IMapper mapper)
		{
			Field<Locations.LocationType>(
				"createLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Locations.LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var location = context.GetArgument<Locations.Location>("location");

					location.Id = Guid.NewGuid();

					dbContext.Locations.Add(new Kitchn.Data.Models.Location
					{
						Id = location.Id,
						Name = location.Name
					});
					dbContext.SaveChanges();

					return location;
				}
			);

			Field<Locations.LocationType>(
				"updateLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Locations.LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var location = context.GetArgument<Locations.Location>("location");

					var dbLocation = dbContext.Locations
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbLocation == null)
					{
						return null;
					}

					dbLocation.Name = location.Name;

					dbContext.Locations.Update(dbLocation);
					dbContext.SaveChanges();

					return mapper.Map<Locations.Location>(dbLocation);
				}
			);

			Field<Locations.LocationType>(
				"deleteLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbLocation = dbContext.Locations
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbLocation == null)
					{
						return null;
					}

					dbContext.Remove(dbLocation);
					dbContext.SaveChanges();

					return mapper.Map<Locations.Location>(dbLocation);
				}
			);

			Field<Measurements.MeasurementType>(
				"createMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Measurements.MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var measurement = context.GetArgument<Measurements.Measurement>("measurement");

					measurement.Id = Guid.NewGuid();

					dbContext.Measurements.Add(new Kitchn.Data.Models.Measurement
					{
						Id = measurement.Id,
						Name = measurement.Name,
						MultipleName = measurement.MultipleName
					});
					dbContext.SaveChanges();

					return measurement;
				}
			);

			Field<Measurements.MeasurementType>(
				"updateMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Measurements.MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var measurement = context.GetArgument<Measurements.Measurement>("measurement");

					var dbMeasurement = dbContext.Measurements
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbMeasurement == null)
					{
						return null;
					}

					dbMeasurement.Name = measurement.Name ?? dbMeasurement.Name;
					dbMeasurement.MultipleName = measurement.MultipleName ?? dbMeasurement.MultipleName;

					dbContext.Measurements.Update(dbMeasurement);
					dbContext.SaveChanges();

					return mapper.Map<Measurements.Measurement>(dbMeasurement);
				}
			);

			Field<Measurements.MeasurementType>(
				"deleteMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbMeasurement = dbContext.Measurements
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbMeasurement == null)
					{
						return null;
					}

					dbContext.Remove(dbMeasurement);
					dbContext.SaveChanges();

					return mapper.Map<Measurements.Measurement>(dbMeasurement);
				}
			);

			Field<Chores.ChoreType>(
				"createChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Chores.ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var chore = context.GetArgument<Chores.Chore>("chore");

					chore.Id = Guid.NewGuid();

					dbContext.Chores.Add(new Kitchn.Data.Models.Chore
					{
						Id = chore.Id,
						Title = chore.Title,
						Description = chore.Description
					});
					dbContext.SaveChanges();

					return chore;
				}
			);

			Field<Chores.ChoreType>(
				"updateChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Chores.ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var chore = context.GetArgument<Chores.Chore>("chore");

					var dbChore = dbContext.Chores
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbChore == null)
					{
						return null;
					}

					dbChore.Title = chore.Title ?? dbChore.Title;
					dbChore.Description = chore.Description ?? dbChore.Description;

					dbContext.Chores.Update(dbChore);
					dbContext.SaveChanges();

					return mapper.Map<Chores.Chore>(dbChore);
				}
			);

			Field<Chores.ChoreType>(
				"deleteChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbChore = dbContext.Chores
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbChore == null)
					{
						return null;
					}

					dbContext.Remove(dbChore);
					dbContext.SaveChanges();

					return mapper.Map<Chores.Chore>(dbChore);
				}
			);

			Field<RecipeCategories.RecipeCategoryType>(
				"createRecipeCategory",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<RecipeCategories.RecipeCategoryInputType>> { Name = "recipecategory" }
				),
				resolve: context =>
				{
					var recipecategory = context.GetArgument<RecipeCategories.RecipeCategory>("recipecategory");

					recipecategory.Id = Guid.NewGuid();

					dbContext.RecipeCategories.Add(new Kitchn.Data.Models.RecipeCategory
					{
						Id = recipecategory.Id,
						Name = recipecategory.Name
					});
					dbContext.SaveChanges();

					return recipecategory;
				}
			);

			Field<RecipeCategories.RecipeCategoryType>(
				"updateRecipeCategory",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<RecipeCategories.RecipeCategoryInputType>> { Name = "recipecategory" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var recipecategory = context.GetArgument<RecipeCategories.RecipeCategory>("recipecategory");

					var dbRecipeCategory = dbContext.RecipeCategories
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbRecipeCategory == null)
					{
						return null;
					}

					dbRecipeCategory.Name = recipecategory.Name ?? dbRecipeCategory.Name;

					dbContext.RecipeCategories.Update(dbRecipeCategory);
					dbContext.SaveChanges();

					return mapper.Map<RecipeCategories.RecipeCategory>(dbRecipeCategory);
				}
			);

			Field<RecipeCategories.RecipeCategoryType>(
				"deleteRecipeCategory",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbRecipeCategory = dbContext.RecipeCategories
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbRecipeCategory == null)
					{
						return null;
					}

					dbContext.Remove(dbRecipeCategory);
					dbContext.SaveChanges();

					return new RecipeCategories.RecipeCategory
					{
						Id = dbRecipeCategory.Id,
						Name = dbRecipeCategory.Name
					};
				}
			);

			Field<Recipes.RecipeType>(
				"createRecipe",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Recipes.RecipeInputType>> { Name = "recipe" }
				),
				resolve: context =>
				{
					var recipe = context.GetArgument<Recipes.Recipe>("recipe");

					recipe.Id = Guid.NewGuid();

					dbContext.Recipes.Add(new Kitchn.Data.Models.Recipe
					{
						Id = recipe.Id,
						Name = recipe.Name,
						Description = recipe.Description,
						Rating = recipe.Rating
					});
					dbContext.SaveChanges();

					return recipe;
				}
			);

			Field<Recipes.RecipeType>(
				"updateRecipe",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Recipes.RecipeInputType>> { Name = "recipe" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var recipe = context.GetArgument<Recipes.Recipe>("recipe");

					var dbRecipe = dbContext.Recipes
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbRecipe == null)
					{
						return null;
					}

					dbRecipe.Name = recipe.Name ?? dbRecipe.Name;
					dbRecipe.Description = recipe.Description ?? dbRecipe.Description;
					dbRecipe.Rating = recipe.Rating ?? dbRecipe.Rating;

					dbContext.Recipes.Update(dbRecipe);
					dbContext.SaveChanges();

					return mapper.Map<Recipes.Recipe>(dbRecipe);
				}
			);

			Field<Recipes.RecipeType>(
				"deleteRecipe",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbRecipe = dbContext.Recipes
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbRecipe == null)
					{
						return null;
					}

					dbContext.Remove(dbRecipe);
					dbContext.SaveChanges();

					return mapper.Map<Recipes.Recipe>(dbRecipe);
				}
			);

			Field<Recipes.RecipeType>(
				"addRecipeToCategory",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "recipeId" },
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "recipeCategoryId" }
				),
				resolve: context =>
				{
					var recipeId = context.GetArgument<Guid>("recipeId");
					var recipeCategoryId = context.GetArgument<Guid>("recipeCategoryId");

					var dbRecipe = dbContext.Recipes
						.Include(o => o.Categories)
						.Where(q => q.Id == recipeId)
						.FirstOrDefault();

					var dbRecipeCategory = dbContext.RecipeCategories
						.Where(q => q.Id == recipeCategoryId)
						.FirstOrDefault();

					if (dbRecipe == null || dbRecipeCategory == null)
					{
						return null;
					}

					dbRecipe.Categories.Add(new Data.Models.RecipeCategoryRecipe
					{
						Recipe = dbRecipe,
						RecipeCategory = dbRecipeCategory
					});
					dbContext.SaveChanges();

					return mapper.Map<Recipes.Recipe>(dbRecipe);
				}
			);

			Field<Products.ProductType>(
				"createProduct",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Products.ProductInputType>> { Name = "product" }
				),
				resolve: context =>
				{
					var product = context.GetArgument<Products.Product>("product");

					product.Id = Guid.NewGuid();

					dbContext.Products.Add(new Kitchn.Data.Models.Product
					{
						Id = product.Id,
						Name = product.Name,
						DefaultBestBefore = product.DefaultBestBefore,
						DefaultLocationId = product.DefaultLocationId,
						DefaultConsumeWithin = product.DefaultConsumeWithin
					});
					dbContext.SaveChanges();

					return product;
				}
			);

			Field<Products.ProductType>(
				"updateProduct",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Products.ProductInputType>> { Name = "product" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var product = context.GetArgument<Products.Product>("product");

					var dbProduct = dbContext.Products
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbProduct == null)
					{
						return null;
					}

					dbProduct.Name = product.Name ?? dbProduct.Name;
					dbProduct.DefaultBestBefore = product.DefaultBestBefore ?? dbProduct.DefaultBestBefore;
					dbProduct.DefaultLocationId = product.DefaultLocationId ?? dbProduct.DefaultLocationId;
					dbProduct.DefaultConsumeWithin = product.DefaultConsumeWithin ?? dbProduct.DefaultConsumeWithin;

					dbContext.Products.Update(dbProduct);
					dbContext.SaveChanges();

					return mapper.Map<Products.Product>(dbProduct);
				}
			);

			Field<Products.ProductType>(
				"deleteProduct",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbProduct = dbContext.Products
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbProduct == null)
					{
						return null;
					}

					dbContext.Remove(dbProduct);
					dbContext.SaveChanges();

					return mapper.Map<Products.Product>(dbProduct);
				}
			);

			Field<Products.ProductType>(
				"applyBarcodeToProduct",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" },
					new QueryArgument<NonNullGraphType<ProductBarcodes.ProductBarcodeInputType>> { Name = "barcode" }
				),
				resolve: context =>
				{
					var barcode = context.GetArgument<ProductBarcodes.ProductBarcode>("barcode");
					var productId = context.GetArgument<Guid>("productId");

					barcode.Id = Guid.NewGuid();

					var dbProduct = dbContext.Products.Where(p => p.Id == productId).FirstOrDefault();

					if (dbProduct == null)
					{
						return null;
					}

					dbContext.ProductBarcodes.Add(new Data.Models.ProductBarcode
					{
						Id = barcode.Id,
						Barcode = barcode.Barcode,
						ProductId = productId
					});

					dbContext.SaveChanges();

					return mapper.Map<Products.Product>(dbProduct);
				}
			);

			Field<StockedItems.StockedItemType>(
				"createStockedItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<StockedItems.StockedItemInputType>> { Name = "stockedItem" }
				),
				resolve: context =>
				{
					var stockeditem = context.GetArgument<StockedItems.StockedItem>("stockedItem");

					if (stockeditem.ProductId == null)
					{
						// ProductId is required
						return null;
					}

					stockeditem.Id = Guid.NewGuid();

					dbContext.StockedItems.Add(new Kitchn.Data.Models.StockedItem
					{
						Id = stockeditem.Id,
						ProductId = stockeditem.ProductId.Value,
						LocationId = stockeditem.LocationId,
						ExpiryDate = stockeditem.ExpiryDate,
						OpenedDate = stockeditem.OpenedDate
					});
					dbContext.SaveChanges();

					return stockeditem;
				}
			);

			Field<StockedItems.StockedItemType>(
				"updateStockedItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<StockedItems.StockedItemInputType>> { Name = "stockedItem" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var stockeditem = context.GetArgument<StockedItems.StockedItem>("stockedItem");

					var dbStockedItem = dbContext.StockedItems
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbStockedItem == null)
					{
						return null;
					}

					dbStockedItem.ProductId = stockeditem.ProductId ?? dbStockedItem.ProductId;
					dbStockedItem.LocationId = stockeditem.LocationId ?? dbStockedItem.LocationId;
					dbStockedItem.ExpiryDate = stockeditem.ExpiryDate ?? dbStockedItem.ExpiryDate;
					dbStockedItem.OpenedDate = stockeditem.OpenedDate ?? dbStockedItem.OpenedDate;

					dbContext.StockedItems.Update(dbStockedItem);
					dbContext.SaveChanges();

					return mapper.Map<StockedItems.StockedItem>(dbStockedItem);
				}
			);

			Field<StockedItems.StockedItemType>(
				"deleteStockedItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbStockedItem = dbContext.StockedItems
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbStockedItem == null)
					{
						return null;
					}

					dbContext.Remove(dbStockedItem);
					dbContext.SaveChanges();

					return mapper.Map<StockedItems.StockedItem>(dbStockedItem);
				}
			);

		}
	}
}