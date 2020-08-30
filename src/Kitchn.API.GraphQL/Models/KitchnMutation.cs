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

			Field<LocationType>(
				"deleteLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbLocation = dbContext.Locations
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbLocation == null)
					{
						return null;
					}

					dbContext.Remove(dbLocation);
					dbContext.SaveChanges();

					return new Location
					{
						Id = dbLocation.Id,
						Name = dbLocation.Name
					};
				}
			);

			Field<MeasurementType>(
				"createMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var measurement = context.GetArgument<Measurement>("measurement");

					dbContext.Measurements.Add(new Kitchn.Data.Models.Measurement
					{
						Id = Guid.NewGuid(),
						Name = measurement.Name,
						MultipleName = measurement.MultipleName
					});
					dbContext.SaveChanges();

					return measurement;
				}
			);

			Field<MeasurementType>(
				"updateMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var measurement = context.GetArgument<Measurement>("measurement");

					var dbMeasurement = dbContext.Measurements
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbMeasurement == null)
					{
						return null;
					}

					dbMeasurement.Name = measurement.Name ?? dbMeasurement.Name;
					dbMeasurement.MultipleName = measurement.MultipleName ?? dbMeasurement.MultipleName;

					dbContext.Measurements.Update(dbMeasurement);
					dbContext.SaveChanges();

					return new Measurement
					{
						Id = dbMeasurement.Id,
						Name = dbMeasurement.Name,
						MultipleName = dbMeasurement.MultipleName
					};
				}
			);

			Field<MeasurementType>(
				"deleteMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbMeasurement = dbContext.Measurements
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbMeasurement == null)
					{
						return null;
					}

					dbContext.Remove(dbMeasurement);
					dbContext.SaveChanges();

					return new Measurement
					{
						Id = dbMeasurement.Id,
						Name = dbMeasurement.Name
					};
				}
			);

			Field<ChoreType>(
				"createChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var chore = context.GetArgument<Chore>("chore");

					dbContext.Chores.Add(new Kitchn.Data.Models.Chore
					{
						Id = Guid.NewGuid(),
						Title = chore.Title,
						Description = chore.Description
					});
					dbContext.SaveChanges();

					return chore;
				}
			);

			Field<ChoreType>(
				"updateChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var chore = context.GetArgument<Chore>("chore");

					var dbChore = dbContext.Chores
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbChore == null)
					{
						return null;
					}

					dbChore.Title = chore.Title ?? dbChore.Title;
					dbChore.Description = chore.Description ?? dbChore.Description;

					dbContext.Chores.Update(dbChore);
					dbContext.SaveChanges();

					return new Chore
					{
						Id = dbChore.Id,
						Title = dbChore.Title,
						Description = dbChore.Description
					};
				}
			);

			Field<ChoreType>(
				"deleteChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");

					var dbChore = dbContext.Chores
						.Where(q => q.Id == id)
						.FirstOrDefault();

					if (dbChore == null)
					{
						return null;
					}

					dbContext.Remove(dbChore);
					dbContext.SaveChanges();

					return new Chore
					{
						Id = dbChore.Id,
						Title = dbChore.Title,
						Description = dbChore.Description,
					};
				}
			);
		}
	}
}