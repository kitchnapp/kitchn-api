using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;

namespace Kitchn.API.GraphQL.Models.MeasurementConversions
{
	public class MeasurementConversionType : ObjectGraphType<MeasurementConversion>
	{
		public MeasurementConversionType(KitchnDbContext dbContext)
		{
			Name = "MeasurementConversion";
			Description = "A measurement conversion between two measurements.";

			Field(x => x.Id).Description("The ID of the measurement conversion.");
			Field(x => x.Factor).Description("The factor to convert from this measurement to the other.");

			Field<Measurements.MeasurementType>("toMeasurement", "The measurement to convert from",
				resolve: context =>
				{
					return dbContext.Measurements
						.Where(o => o.Id == context.Source.ToMeasurementId)
						.Select(dbMeasurement => new Measurements.Measurement
						{
							Id = dbMeasurement.Id,
							Name = dbMeasurement.Name,
							MultipleName = dbMeasurement.MultipleName,
						})
						.FirstOrDefault();
				});

			Field<Measurements.MeasurementType>("fromMeasurement", "The measurement to convert from",
				resolve: context =>
				{
					return dbContext.Measurements
						.Where(o => o.Id == context.Source.FromMeasurementId)
						.Select(dbMeasurement => new Measurements.Measurement
						{
							Id = dbMeasurement.Id,
							Name = dbMeasurement.Name,
							MultipleName = dbMeasurement.MultipleName,
						})
						.FirstOrDefault();
				});
		}
	}
}