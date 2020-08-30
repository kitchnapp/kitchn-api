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
			Field<Locations.LocationType>(
				"createLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Locations.LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var location = context.GetArgument<Locations.Location>("location");

					dbContext.Locations.Add(new Kitchn.Data.Models.Location
					{
						Id = Guid.NewGuid(),
						Name = location.Name
					});
					dbContext.SaveChanges();

					return location;
				}
			);

			Field<Locations.LocationType>(
				"updateLocation",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Locations.LocationInputType>> { Name = "location" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var location = context.GetArgument<Locations.Location>("location");

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

					return new Locations.Location
					{
						Id = dbLocation.Id,
						Name = dbLocation.Name
					};
				}
			);

			Field<Locations.LocationType>(
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

					return new Locations.Location
					{
						Id = dbLocation.Id,
						Name = dbLocation.Name
					};
				}
			);

			Field<Measurements.MeasurementType>(
				"createMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Measurements.MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var measurement = context.GetArgument<Measurements.Measurement>("measurement");

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

			Field<Measurements.MeasurementType>(
				"updateMeasurement",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Measurements.MeasurementInputType>> { Name = "measurement" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var measurement = context.GetArgument<Measurements.Measurement>("measurement");

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

					return new Measurements.Measurement
					{
						Id = dbMeasurement.Id,
						Name = dbMeasurement.Name,
						MultipleName = dbMeasurement.MultipleName
					};
				}
			);

			Field<Measurements.MeasurementType>(
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

					return new Measurements.Measurement
					{
						Id = dbMeasurement.Id,
						Name = dbMeasurement.Name,
						MultipleName = dbMeasurement.MultipleName
					};
				}
			);

			Field<Chores.ChoreType>(
				"createChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<Chores.ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var chore = context.GetArgument<Chores.Chore>("chore");

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

			Field<Chores.ChoreType>(
				"updateChore",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
					new QueryArgument<NonNullGraphType<Chores.ChoreInputType>> { Name = "chore" }
				),
				resolve: context =>
				{
					var id = context.GetArgument<Guid>("id");
					var chore = context.GetArgument<Chores.Chore>("chore");

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

					return new Chores.Chore
					{
						Id = dbChore.Id,
						Title = dbChore.Title,
						Description = dbChore.Description
					};
				}
			);

			Field<Chores.ChoreType>(
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

					return new Chores.Chore
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