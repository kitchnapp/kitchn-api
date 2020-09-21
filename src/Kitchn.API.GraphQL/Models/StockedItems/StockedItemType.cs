using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.StockedItems
{
	public class StockedItemType : ObjectGraphType<StockedItem>
	{
		public StockedItemType(KitchnDbContext dbContext)
		{
			Name = "StockedItem";
			Description = "An item in stock.";

			Field(x => x.Id).Description("The ID of the stocked item.");

			Field<TimeSpanSecondsGraphType>("expiryDate", "The expiry date for the stocked item.");
			Field<TimeSpanSecondsGraphType>("openedDate", "The date the stocked item was opened.");

			Field<Products.ProductType>("product", "The stocked product.",
				resolve: context =>
				{
					return dbContext.Products
						.Where(q => q.Id == context.Source.ProductId)
						.Select(product => new Products.Product
						{
							Id = product.Id,
							Name = product.Name,
							DefaultBestBefore = product.DefaultBestBefore,
							DefaultConsumeWithin = product.DefaultConsumeWithin,
							DefaultLocationId = product.DefaultLocationId
						})
						.FirstOrDefault();
				}
			);

			Field<Locations.LocationType>("location", "Where the stocked product is located.",
				resolve: context =>
				{
					return dbContext.Locations
						.Where(q => q.Id == context.Source.LocationId)
						.Select(location => new Locations.Location
						{
							Id = location.Id,
							Name = location.Name,
						})
						.FirstOrDefault();
				}
			);
		}
	}
}