using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnQuery : ObjectGraphType
	{
		public KitchnQuery(KitchnDbContext dbContext, IMapper mapper)
		{
			Field<Products.ProductType>(
				"product",
				"Get product by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return mapper.Map<Products.Product>(
						dbContext.Products
							.Where(q => q.Id == id)
							.FirstOrDefault()
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Products.ProductType>>>>(
				"products",
				"Get product by search",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "barcode" },
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var barcode = context.GetArgument<string>("barcode");
					var search = context.GetArgument<string>("search");

					IQueryable<Data.Models.Product> baseQuery = dbContext.Products;
					if (!string.IsNullOrEmpty(barcode))
					{
						baseQuery = baseQuery
							.Include(product => product.ProductBarcodes)
							.Where(q => q.ProductBarcodes.Any(b => b.Barcode == barcode));
					}

					return mapper.Map<IEnumerable<Products.Product>>(
						baseQuery
							.Where(q => search == null || EF.Functions.Like(q.Name, search))
					);
				}
			);

			Field<Locations.LocationType>(
				"location",
				"Get location by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return mapper.Map<Locations.Location>(
						dbContext.Locations
							.Where(q => q.Id == id)
							.FirstOrDefault()
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Locations.LocationType>>>>(
				"locations",
				"Get a list of locations",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return mapper.Map<IEnumerable<Locations.Location>>(
						dbContext.Locations
							.Where(q => q.Name.Contains(search) || search == null)
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Measurements.MeasurementType>>>>(
				"measurements",
				"Get a list of measurements",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return mapper.Map<IEnumerable<Measurements.Measurement>>(
						dbContext.Measurements
							.Where(q => q.Name.Contains(search) || search == null)
					);
				}
			);

			Field<Measurements.MeasurementType>(
				"measurement",
				"Get measurement by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return mapper.Map<Measurements.Measurement>(
						dbContext.Measurements
							.Where(q => q.Id == id)
							.FirstOrDefault()
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Chores.ChoreType>>>>(
				"chores",
				"Get a list of chores",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return mapper.Map<IEnumerable<Chores.Chore>>(
						dbContext.Chores
							.Where(q => q.Title.Contains(search) || search == null)
					);
				}
			);

			Field<Chores.ChoreType>(
				"chore",
				"Get chore by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return mapper.Map<Chores.Chore>(
						dbContext.Chores
							.Where(q => q.Id == id)
							.FirstOrDefault()
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Recipes.RecipeType>>>>(
				"recipes",
				"Get a list of recipes",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return mapper.Map<IEnumerable<Recipes.Recipe>>(
						dbContext.Recipes
							.Where(q => q.Name.Contains(search) || search == null)
					);
				}
			);

			Field<Recipes.RecipeType>(
				"recipe",
				"Get recipe by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return mapper.Map<IEnumerable<Recipes.Recipe>>(
						dbContext.Recipes
							.Where(q => q.Id == id)
							.FirstOrDefault()
					);
				}
			);

			Field<RecipeCategories.RecipeCategoryType>(
				"recipeCategory",
				"Get recipe category by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return mapper.Map<RecipeCategories.RecipeCategory>(
						dbContext.RecipeCategories
							.Where(q => q.Id == id)
							.FirstOrDefault()
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<RecipeCategories.RecipeCategoryType>>>>(
				"recipeCategories",
				"Get a list of recipe categories",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return mapper.Map<IEnumerable<RecipeCategories.RecipeCategory>>(
						dbContext.RecipeCategories
							.Where(q => q.Name.Contains(search) || search == null)
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<StockedItems.StockedItemType>>>>(
				"stockedItems",
				"Get a list of stocked items",
				resolve: context =>
				{
					return mapper.Map<IEnumerable<StockedItems.StockedItem>>(
						dbContext.StockedItems
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<Batteries.BatteryType>>>>(
				"batteries",
				"Get a list of stocked batteries",
				resolve: context =>
				{
					return mapper.Map<IEnumerable<Batteries.Battery>>(
						dbContext.Batteries
					);
				}
			);
		}
	}
}