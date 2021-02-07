using System;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Interfaces;
using Kitchn.API.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnMutation : ObjectGraphType
	{
		public KitchnMutation(
			KitchnDbContext dbContext, 
			IMapper mapper, 
			UserManager<IdentityUser> userManager, 
			SignInManager<IdentityUser> signInManager,
			IRepository<Battery> batteryRepository,
			IRepository<Chore> choreRepository,
			IRepository<Location> locationRepository,
			IRepository<StockedItem> stockedItemRepository,
			IRepository<Recipe> recipeRepository
		){
			Field<Locations.LocationType>(
				"createLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Locations.LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var location = context.GetArgument<Location>("location");

					return locationRepository.AddAsync(location).Result;
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
					var location = context.GetArgument<Location>("location");

					location.Id = id;

					return locationRepository.UpdateAsync(location).Result;
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

					var location = new Location { Id = id };

					locationRepository.DeleteAsync(location);

					return location;
				}
			);

			Field<Measurements.MeasurementType>(
				"createMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Measurements.MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var measurement = context.GetArgument<Measurement>("measurement");

					measurement.Id = Guid.NewGuid();

					dbContext.Measurements.Add(new Kitchn.API.Data.Models.Measurement
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
					var measurement = context.GetArgument<Measurement>("measurement");

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

					return mapper.Map<Measurement>(dbMeasurement);
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

					return mapper.Map<Measurement>(dbMeasurement);
				}
			);

			Field<Chores.ChoreType>(
				"createChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Chores.ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var chore = context.GetArgument<Chore>("chore");

					return choreRepository.AddAsync(chore).Result;
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
					var chore = context.GetArgument<Chore>("chore");

					chore.Id = id;

					return choreRepository.UpdateAsync(chore).Result;
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

					var chore = new Chore { Id = id };

					choreRepository.DeleteAsync(chore);

					return chore;
				}
			);

			Field<RecipeCategories.RecipeCategoryType>(
				"createRecipeCategory",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<RecipeCategories.RecipeCategoryInputType>> { Name = "recipecategory" }
				),
				resolve: context =>
				{
					var recipecategory = context.GetArgument<RecipeCategory>("recipecategory");

					recipecategory.Id = Guid.NewGuid();

					dbContext.RecipeCategories.Add(new Kitchn.API.Data.Models.RecipeCategory
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
					var recipecategory = context.GetArgument<RecipeCategory>("recipecategory");

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

					return mapper.Map<RecipeCategory>(dbRecipeCategory);
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

					return mapper.Map<RecipeCategory>(dbRecipeCategory);
				}
			);

			Field<Recipes.RecipeType>(
				"createRecipe",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Recipes.RecipeInputType>> { Name = "recipe" }
				),
				resolve: context =>
				{
					var recipe = context.GetArgument<Recipe>("recipe");

					recipe.Id = Guid.NewGuid();

					dbContext.Recipes.Add(new Kitchn.API.Data.Models.Recipe
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
					var recipe = context.GetArgument<Recipe>("recipe");

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

					return mapper.Map<Recipe>(dbRecipe);
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

					return mapper.Map<Recipe>(dbRecipe);
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

					return mapper.Map<Recipe>(dbRecipe);
				}
			);

			Field<Products.ProductType>(
				"createProduct",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Products.ProductInputType>> { Name = "product" }
				),
				resolve: context =>
				{
					var product = context.GetArgument<Product>("product");

					product.Id = Guid.NewGuid();

					dbContext.Products.Add(new Kitchn.API.Data.Models.Product
					{
						Id = product.Id,
						Name = product.Name,
						DefaultBestBefore = product.DefaultBestBefore,
						DefaultLocationId = product.DefaultLocationId,
						DefaultConsumeWithin = product.DefaultConsumeWithin,
						ConsumeFactor = product.ConsumeFactor
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
					var product = context.GetArgument<Product>("product");

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
					dbProduct.ConsumeFactor = product.ConsumeFactor ?? dbProduct.ConsumeFactor;

					dbContext.Products.Update(dbProduct);
					dbContext.SaveChanges();

					return mapper.Map<Product>(dbProduct);
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

					return mapper.Map<Product>(dbProduct);
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
					var barcode = context.GetArgument<ProductBarcode>("barcode");
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

					return mapper.Map<Product>(dbProduct);
				}
			);

			Field<StockedItems.StockedItemType>(
				"createStockedItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<StockedItems.StockedItemInputType>> { Name = "stockedItem" }
				),
				resolve: context =>
				{
					var stockedItem = context.GetArgument<StockedItem>("stockedItem");

					return stockedItemRepository.AddAsync(stockedItem).Result;
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
					var stockedItem = context.GetArgument<StockedItem>("stockedItem");

					stockedItem.Id = id;

					return stockedItemRepository.UpdateAsync(stockedItem).Result;
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

					var stockedItem = new StockedItem { Id = id };

					stockedItemRepository.DeleteAsync(stockedItem);

					return stockedItem;
				}
			);

			Field<Batteries.BatteryType>(
				"createBattery",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Batteries.BatteryInputType>> { Name = "battery" }
				),
				resolve: context =>
				{
					var battery = context.GetArgument<Battery>("battery");

					return batteryRepository.AddAsync(battery).Result;
				}
			);

			Field<Batteries.BatteryType>(
				"updateBattery",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Batteries.BatteryInputType>> { Name = "battery" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var battery = context.GetArgument<Battery>("battery");

					battery.Id = id;

					return batteryRepository.UpdateAsync(battery).Result;
				}
			);

			Field<Batteries.BatteryType>(
				"deleteBattery",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var battery = new Battery { Id = id };

					batteryRepository.DeleteAsync(battery);

					return mapper.Map<Battery>(battery);
				}
			);

			Field<StockedItems.StockedItemType>(
				"consumeStockedItem",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<IntGraphType> { Name = "partialCount" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var partialConsumingCount = context.GetArgument<int?>("partialCount");

					var dbStockedItem = dbContext.StockedItems
						.Include(o => o.Product)
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbStockedItem == null)
					{
						return null;
					}

					var consumed = true;
					if (partialConsumingCount.HasValue)
					{
						dbStockedItem.ConsumedCount = dbStockedItem.ConsumedCount.GetValueOrDefault(0) + partialConsumingCount;
						if (dbStockedItem.ConsumedCount < dbStockedItem.Product.ConsumeFactor.GetValueOrDefault(1))
							consumed = false;
					}

					if (consumed)
						dbContext.Remove(dbStockedItem);

					dbContext.SaveChanges();

					return mapper.Map<StockedItem>(dbStockedItem);
				}
			);

			Field<Auth.UserType>(
				"login",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "username" },
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
				),
				resolve: context =>
				{
					var username = context.GetArgument<string>("username");
					var password = context.GetArgument<string>("password");

					var result = signInManager.PasswordSignInAsync(username, password, true, lockoutOnFailure: true).Result;

					if (result.Succeeded)
					{
						var user = userManager.FindByNameAsync(username).Result;

						return new User
						{
							Username = user.UserName,
							Email = user.Email,
							Id = user.Id
						};
					}
					else
					{
						return null;
					}
				}
			);

			Field<Auth.UserType>(
				"register",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Auth.CreateUserInputType>> { Name = "user" }
				),
				resolve: context =>
				{
					var newUser = context.GetArgument<User>("user");

					var user = new IdentityUser { UserName = newUser.Username, Email = newUser.Email };
					var result = userManager.CreateAsync(user, newUser.Password).Result;

					if (result.Succeeded)
					{
						var foundUser = userManager.FindByNameAsync(newUser.Username).Result;

						return new User
						{
							Username = foundUser.UserName,
							Email = foundUser.Email,
							Id = foundUser.Id
						};
					}
					else
					{
						return null;
					}
				}
			);
		}
	}
}