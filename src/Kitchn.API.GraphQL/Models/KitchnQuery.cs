using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnQuery : ObjectGraphType
	{
		public KitchnQuery()
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

			Field<LocationType>(
				"location",
				"Get location by ID",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					return new Product
					{
						Id = id,
						Name = "Test Location"
					};
				}
			);

			Field<ListGraphType<LocationType>>(
				"locations",
				"Get a list of locations",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return new List<Location>{
						new Location {
							Id = Guid.NewGuid(),
							Name = "Example"
						}
					};
				}
			);
		}
	}
}