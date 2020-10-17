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
			Field<IntGraphType>("consumeFactor", "The consuming factor of the product.");
			Field<TimeSpanSecondsGraphType>("defaultBestBefore", description: "The default best before in seconds.");
			Field<TimeSpanSecondsGraphType>("defaultConsumeWithin", description: "The default consume within in seconds.");
			Field<IdGraphType>("individualMeasurementId", description: "The individual measurement ID for the product.");
			Field<IdGraphType>("groupMeasurementId", description: "The group measurement ID for the product.");
		}
	}
}