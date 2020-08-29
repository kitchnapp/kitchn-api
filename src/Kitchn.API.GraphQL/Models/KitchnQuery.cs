using System;
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
					new QueryArgument<IdGraphType> { Name = "id" }
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
		}
	}
}