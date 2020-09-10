using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;

namespace Kitchn.API.GraphQL.Models.ProductBarcodes
{
	public class ProductBarcodeType : ObjectGraphType<ProductBarcode>
	{
		public ProductBarcodeType(KitchnDbContext dbContext)
		{
			Name = "ProductBarcode";
			Description = "A barcode for a product.";

			Field(x => x.Id).Description("The ID of the product barcode.");
			Field(x => x.Barcode).Description("A barcode of the product.");
		}
	}
}