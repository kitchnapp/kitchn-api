using System;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Product barcode model
	/// </summary>
	public class ProductBarcode
	{
		/// <summary>
		/// ID of this product barcode
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Product ID which this barcode relates to
		/// </summary>
		public Guid ProductId { get; set; }

		/// <summary>
		/// Navigation property for the product
		/// </summary>
		public Product Product { get; set; }

		/// <summary>
		/// String resultant of the product barcode
		/// </summary>
		public string Barcode { get; set; }
	}
}
