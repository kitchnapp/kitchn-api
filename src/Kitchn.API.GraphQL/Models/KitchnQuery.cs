using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnQuery : ObjectGraphType
	{
		public KitchnQuery(KitchnDbContext dbContext)
		{
			Field<ProductType>(
				"product",
				"Get product by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return new Product
					{
						Id = id,
						Name = "Test"
					};
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

					return dbContext.Locations
						.Where(q => q.Id == id)
						.Select(location => new Locations.Location
						{
							Id = location.Id,
							Name = location.Name
						})
						.FirstOrDefault();
				}
			);

			Field<ListGraphType<Locations.LocationType>>(
				"locations",
				"Get a list of locations",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return dbContext.Locations
							.Where(q => q.Name.Contains(search) || search == null)
							.Select(location => new Locations.Location
							{
								Id = location.Id,
								Name = location.Name
							});
				}
			);

			Field<ListGraphType<Measurements.MeasurementType>>(
				"measurements",
				"Get a list of measurements",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return dbContext.Measurements
							.Where(q => q.Name.Contains(search) || search == null)
							.Select(measurement => new Measurements.Measurement
							{
								Id = measurement.Id,
								Name = measurement.Name,
								MultipleName = measurement.MultipleName
							});
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

					return dbContext.Measurements
						.Where(q => q.Id == id)
						.Select(measurement => new Measurements.Measurement
						{
							Id = measurement.Id,
							Name = measurement.Name,
							MultipleName = measurement.MultipleName
						})
						.FirstOrDefault();
				}
			);

			Field<ListGraphType<Chores.ChoreType>>(
				"chores",
				"Get a list of chores",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return dbContext.Chores
							.Where(q => q.Title.Contains(search) || search == null)
							.Select(chore => new Chores.Chore
							{
								Id = chore.Id,
								Title = chore.Title,
								Description = chore.Description
							});
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

					return dbContext.Chores
						.Where(q => q.Id == id)
						.Select(chore => new Chores.Chore
						{
							Id = chore.Id,
							Title = chore.Title,
							Description = chore.Description
						})
						.FirstOrDefault();
				}
			);

			Field<ListGraphType<Recipes.RecipeType>>(
				"recipes",
				"Get a list of recipes",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return dbContext.Recipes
							.Where(q => q.Name.Contains(search) || search == null)
							.Select(recipe => new Recipes.Recipe
							{
								Id = recipe.Id,
								Name = recipe.Name,
								Description = recipe.Description,
								Rating = recipe.Rating
							});
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

					return dbContext.Recipes
						.Where(q => q.Id == id)
						.Select(recipe => new Recipes.Recipe
						{
							Id = recipe.Id,
							Name = recipe.Name,
							Description = recipe.Description,
							Rating = recipe.Rating
						})
						.FirstOrDefault();
				}
			);
		}
	}
}