using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.Products
{
	public class ProductType : ObjectGraphType<Product>
	{
		public ProductType(KitchnDbContext dbContext, IMapper mapper)
		{
			Name = "Product";
			Description = "A product in the system.";

			Field(x => x.Id).Description("The ID of the product.");
			Field(x => x.Name).Description("The name of the product.");
			Field<IntGraphType>("consumeFactor", "The consume factor of the product.");
			Field<TimeSpanSecondsGraphType>("defaultBestBefore", "The default best before window for the product.");
			Field<TimeSpanSecondsGraphType>("defaultConsumeWithin", "The default consuming window for the product.");

			Field<Locations.LocationType>("defaultLocation", "The default location for the product.",
				resolve: context =>
				{
					return mapper.Map<Location>(
						dbContext.Locations
							.Where(q => q.Id == context.Source.DefaultLocationId)
							.FirstOrDefault()
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<StockedItems.StockedItemType>>>>("stockedItems", "The stocked items of the product.",
				resolve: context =>
				{
					return mapper.Map<IEnumerable<StockedItem>>(
						dbContext.StockedItems
							.Where(q => q.ProductId == context.Source.Id)
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<ProductBarcodes.ProductBarcodeType>>>>("barcodes", "The barcodes for the product.",
				resolve: context =>
				{
					return mapper.Map<IEnumerable<ProductBarcode>>(
						dbContext.ProductBarcodes
							.Where(q => q.ProductId == context.Source.Id)
					);
				}
			);

			Field<Measurements.MeasurementType>("individualMeasurement", "The individual measurement for the product.",
				resolve: context =>
				{
					return mapper.Map<Measurement>(
						dbContext.Measurements
							.FirstOrDefault(q => q.Id == context.Source.IndividualMeasurementId)
					);
				}
			);

			Field<Measurements.MeasurementType>("groupMeasurement", "The group measurement for the product.",
				resolve: context =>
				{
					return mapper.Map<Measurement>(
						dbContext.Measurements
							.FirstOrDefault(q => q.Id == context.Source.GroupMeasurementId)
					);
				}
			);
		}
	}
}