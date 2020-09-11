using GraphQL;
using GraphQL.Types;

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