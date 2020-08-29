using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models
{
	public class ProductType : ObjectGraphType<Product>
	{
		public ProductType()
		{
			Name = "Product";
			Description = "A mechanical creature in the Star Wars universe.";

			Field(x => x.Id).Description("The ID of the product.");
			Field(x => x.Name).Description("The name of the product.");
		}
	}
}