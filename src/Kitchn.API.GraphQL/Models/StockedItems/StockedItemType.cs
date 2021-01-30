using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.StockedItems
{
	public class StockedItemType : ObjectGraphType<StockedItem>
	{
		public StockedItemType(KitchnDbContext dbContext, IMapper mapper)
		{
			Name = "StockedItem";
			Description = "An item in stock.";

			Field(x => x.Id).Description("The ID of the stocked item.");
			Field<IntGraphType>("consumedCount", "The amount of times this item has been consumed.");
			Field<DateTimeGraphType>("expiryDate", "The expiry date for the stocked item.");
			Field<DateTimeGraphType>("openedDate", "The date the stocked item was opened.");

			Field<Products.ProductType>("product", "The stocked product.",
				resolve: context =>
				{
					return mapper.Map<Products.Product>(
						dbContext.Products
							.Where(q => q.Id == context.Source.ProductId)
							.FirstOrDefault()
					);
				}
			);

			Field<Locations.LocationType>("location", "Where the stocked product is located.",
				resolve: context =>
				{
					return mapper.Map<Locations.Location>(
						dbContext.Locations
							.Where(q => q.Id == context.Source.LocationId)
							.FirstOrDefault()
					);
				}
			);
		}
	}
}