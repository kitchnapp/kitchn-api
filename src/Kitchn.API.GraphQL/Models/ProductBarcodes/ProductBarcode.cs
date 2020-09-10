using System;

namespace Kitchn.API.GraphQL.Models.ProductBarcodes
{
	public class ProductBarcode
	{
		public Guid Id { get; set; }
		public string Barcode { get; set; }
	}
}