using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.ProductBarcodes
{
	public class ProductBarcodeInputType : InputObjectGraphType<ProductBarcode>
	{
		public ProductBarcodeInputType()
		{
			Name = "ProductBarcodeInput";

			Field(x => x.Barcode).Description("The barcode of the product.");
		}
	}
}