using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Interfaces;
using Kitchn.API.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnQuery : ObjectGraphType
	{
		public KitchnQuery(
			KitchnDbContext dbContext,
			IMapper mapper,
			IRepository<Battery> batteryRepository,
			IRepository<Chore> choreRepository,
			IRepository<Location> locationRepository,
			IRepository<StockedItem> stockedItemRepository,
			IRepository<Recipe> recipeRepository,
			IRepository<RecipeCategory> recipeCategoryRepository,
			IRepository<Measurement> measurementRepository
		){
			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Products.ProductType>>>>(
				"products",
				"Get products",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "barcode" }
				),
				resolve: context =>
				{
					var barcode = context.GetArgument<string>("barcode");

					IQueryable<Data.Models.Product> baseQuery = dbContext.Products;
					if (!string.IsNullOrEmpty(barcode))
					{
						baseQuery = baseQuery
							.Include(product => product.ProductBarcodes)
							.Where(q => q.ProductBarcodes.Any(b => b.Barcode == barcode));
					}

					return mapper.Map<IEnumerable<Product>>(
						baseQuery
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Locations.LocationType>>>>(
				"locations",
				"Get a list of locations",
				resolve: context =>
				{
					return locationRepository.GetAsync().Result;
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Measurements.MeasurementType>>>>(
				"measurements",
				"Get a list of measurements",
				resolve: context =>
				{
					return measurementRepository.GetAsync().Result;
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Chores.ChoreType>>>>(
				"chores",
				"Get a list of chores",
				resolve: context =>
				{
					return choreRepository.GetAsync().Result;
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Recipes.RecipeType>>>>(
				"recipes",
				"Get a list of recipes",
				resolve: context =>
				{
					return recipeRepository.GetAsync().Result;
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<RecipeCategories.RecipeCategoryType>>>>(
				"recipeCategories",
				"Get a list of recipe categories",
				resolve: context =>
				{
					return recipeCategoryRepository.GetAsync().Result;
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<StockedItems.StockedItemType>>>>(
				"stockedItems",
				"Get a list of stocked items",
				resolve: context =>
				{
					return stockedItemRepository.GetAsync().Result;
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Batteries.BatteryType>>>>(
				"batteries",
				"Get a list of stocked batteries",
				resolve: context =>
				{
					return batteryRepository.GetAsync().Result;
				}
			);
		}
	}
}