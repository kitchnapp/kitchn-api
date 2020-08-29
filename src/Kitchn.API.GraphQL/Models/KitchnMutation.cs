using System;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnMutation : ObjectGraphType
	{
		public KitchnMutation(KitchnDbContext dbContext)
		{
			Field<LocationType>(
				"createLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var location = context.GetArgument<Location>("location");

					dbContext.Locations.Add(new Kitchn.Data.Models.Location
					{
						Id = Guid.NewGuid(),
						Name = location.Name
					});
					dbContext.SaveChanges();

					return location;
				}
			);

			Field<LocationType>(
				"updateLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var location = context.GetArgument<Location>("location");

					var dbLocation = dbContext.Locations
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbLocation == null)
					{
						return null;
					}

					dbLocation.Name = location.Name;

					dbContext.Locations.Update(dbLocation);
					dbContext.SaveChanges();

					return new Location
					{
						Id = dbLocation.Id,
						Name = dbLocation.Name
					};
				}
			);
		}
	}
}