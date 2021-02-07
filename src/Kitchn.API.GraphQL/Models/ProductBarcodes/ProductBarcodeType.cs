using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.ProductBarcodes
{
	public class ProductBarcodeType : ObjectGraphType<ProductBarcode>
	{
		public ProductBarcodeType()
		{
			Name = "ProductBarcode";
			Description = "A barcode for a product.";

			Field(x => x.Id).Description("The ID of the product barcode.");
			Field(x => x.Barcode).Description("A barcode of the product.");
		}
	}
}