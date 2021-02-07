using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.Locations
{
	public class LocationType : ObjectGraphType<Location>
	{
		public LocationType()
		{
			Name = "Location";
			Description = "A location where a product can be stored.";

			Field(x => x.Id).Description("The ID of the location.");
			Field(x => x.Name).Description("The name of the location.");
		}
	}
}