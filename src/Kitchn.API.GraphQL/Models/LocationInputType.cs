using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models
{
	public class LocationInputType : InputObjectGraphType<Location>
	{
		public LocationInputType()
		{
			Name = "LocationInput";

			Field(x => x.Name, nullable: true).Description("The name of the location.");
		}
	}
}