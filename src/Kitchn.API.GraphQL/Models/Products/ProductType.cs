using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;

namespace Kitchn.API.GraphQL.Models.Products
{
	public class ProductType : ObjectGraphType<Product>
	{
		public ProductType(KitchnDbContext dbContext)
		{
			Name = "Product";
			Description = "A product in the system.";

			Field(x => x.Id).Description("The ID of the product.");
			Field(x => x.Name).Description("The name of the product.");
			Field<TimeSpanSecondsGraphType>("defaultBestBefore", "The default best before window for the product.");
			Field<TimeSpanSecondsGraphType>("defaultConsumeWithin", "The default consuming window for the product.");

			Field<Models.Locations.LocationType>("defaultLocation", "The default location for the product.",
				resolve: context =>
				{
					return dbContext.Locations
							.Where(q => q.Id == context.Source.DefaultLocationId)
							.Select(location => new Locations.Location
							{
								Id = location.Id,
								Name = location.Name,
							})
							.FirstOrDefault();
				}
			);

			Field<ListGraphType<Models.ProductBarcodes.ProductBarcodeType>>("barcodes", "The barcodes for the product.",
				resolve: context =>
				{
					return dbContext.ProductBarcodes
							.Where(q => q.ProductId == context.Source.Id)
							.Select(productBarcode => new ProductBarcodes.ProductBarcode
							{
								Id = productBarcode.Id,
								Barcode = productBarcode.Barcode,
							});
				}
			);
		}
	}
}