using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.Batteries
{
	public class BatteryType : ObjectGraphType<Battery>
	{
		public BatteryType()
		{
			Name = "Battery";
			Description = "A battery in storage or in use.";

			Field(x => x.Id).Description("The ID of the battery.");
			Field(x => x.Name).Description("The name of the battery.");
			Field(x => x.Location, nullable: true).Description("The current location of the battery.");
			Field(x => x.Rechargeable, nullable: true).Description("The battery rechargeable option.");
			Field<DateTimeGraphType>("lastCharged", "The last time the battery was charged.");
			Field<DateTimeGraphType>("expiryDate", "The expiry date of the battery.");

		}
	}
}