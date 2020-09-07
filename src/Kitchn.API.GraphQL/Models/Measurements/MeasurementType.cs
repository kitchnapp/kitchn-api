using System;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.Measurements
{
	public class MeasurementType : ObjectGraphType<Measurement>
	{
		public MeasurementType(KitchnDbContext dbContext)
		{
			Name = "Measurement";
			Description = "A measurement which a product can be measured in.";

			Field(x => x.Id).Description("The ID of the measurement.");
			Field(x => x.Name).Description("The name of the measurement.");
			Field(x => x.MultipleName, nullable: true).Description("The multiple word of the measurement.");

			Field<ListGraphType<MeasurementConversions.MeasurementConversionType>>("conversions", "The list of possible conversions.",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return dbContext.MeasurementConversions
						.Include(o => o.ToMeasurement)
						.Where(o => search == null || EF.Functions.Like(o.ToMeasurement.Name, search))
						.Where(o =>
							(o.FromMeasurementId == context.Source.Id) ||
							(o.ToMeasurementId == context.Source.Id)
						)
						.Select(dbMeasurementConversion => ConvertDbModelToMeasurement(dbMeasurementConversion, context.Source.Id));
				});

			Field<MeasurementConversions.MeasurementConversionType>("convert", "Convert to a specific ID.",
				arguments: new QueryArguments(
					new QueryArgument<IdGraphType> { Name = "toMeasurementId" }
				),
				resolve: context =>
				{
					var measurementId = context.GetArgument<Guid>("toMeasurementId");

					return dbContext.MeasurementConversions
						.Where(o =>
							(o.ToMeasurementId == measurementId && o.FromMeasurementId == context.Source.Id) ||
							(o.FromMeasurementId == measurementId && o.ToMeasurementId == context.Source.Id)
						)
						.Select(dbMeasurementConversion => ConvertDbModelToMeasurement(dbMeasurementConversion, context.Source.Id))
						.FirstOrDefault();
				});
		}

		private static MeasurementConversions.MeasurementConversion ConvertDbModelToMeasurement(Data.Models.MeasurementConversion dbMeasurementConversion, Guid sourceId)
		{
			return new MeasurementConversions.MeasurementConversion
			{
				Id = dbMeasurementConversion.Id,
				ToMeasurementId = dbMeasurementConversion.ToMeasurementId == sourceId ? dbMeasurementConversion.FromMeasurementId : dbMeasurementConversion.ToMeasurementId,
				FromMeasurementId = dbMeasurementConversion.FromMeasurementId == sourceId ? dbMeasurementConversion.ToMeasurementId : dbMeasurementConversion.FromMeasurementId,
				Factor = dbMeasurementConversion.ToMeasurementId == sourceId ? dbMeasurementConversion.Factor : 1 / dbMeasurementConversion.Factor,
			};
		}
	}
}