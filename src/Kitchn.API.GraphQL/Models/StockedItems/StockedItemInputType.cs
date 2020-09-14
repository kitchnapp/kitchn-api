using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.StockedItems
{
	public class StockedItemInputType : InputObjectGraphType<StockedItem>
	{
		public StockedItemInputType()
		{
			Name = "StockedItemInput";

			Field(x => x.ProductId, nullable: true).Description("The product of the stocked item.");
			Field(x => x.LocationId, nullable: true).Description("The location of the stocked item.");
			Field<TimeSpanSecondsGraphType>("expiryDate", "The expiry date for the stocked item.");
			Field<TimeSpanSecondsGraphType>("openedDate", "The date the stocked item was opened.");
		}
	}
}