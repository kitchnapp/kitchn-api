using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.Products
{
	public class ProductInputType : InputObjectGraphType<Product>
	{
		public ProductInputType()
		{
			Name = "ProductInput";

			Field(x => x.Name, nullable: true).Description("The name of the product.");
			Field(x => x.DefaultLocationId, nullable: true).Description("The default location ID.");
			Field<TimeSpanSecondsGraphType>("defaultBestBefore", description: "The default location ID.");
			Field<TimeSpanSecondsGraphType>("defaultConsumeWithin", description: "The default location ID.");
		}
	}
}