using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.Locations
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