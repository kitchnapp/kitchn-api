using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.MeasurementConversions
{
	public class MeasurementConversionType : ObjectGraphType<MeasurementConversion>
	{
		public MeasurementConversionType(KitchnDbContext dbContext, IMapper mapper)
		{
			Name = "MeasurementConversion";
			Description = "A measurement conversion between two measurements.";

			Field(x => x.Id).Description("The ID of the measurement conversion.");
			Field(x => x.Factor).Description("The factor to convert from this measurement to the other.");

			Field<Measurements.MeasurementType>("toMeasurement", "The measurement to convert from",
				resolve: context =>
				{
					return mapper.Map<Measurement>(
						dbContext.Measurements
							.Where(o => o.Id == context.Source.ToMeasurementId)
							.FirstOrDefault()
					);
				});

			Field<Measurements.MeasurementType>("fromMeasurement", "The measurement to convert from",
				resolve: context =>
				{
					return mapper.Map<Measurement>(
						dbContext.Measurements
							.Where(o => o.Id == context.Source.FromMeasurementId)
							.FirstOrDefault()
					);
				});
		}
	}
}