using System;
using System.Collections.Generic;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Product model
	/// </summary>
	public class Product
	{
		/// <summary>
		/// ID of this product
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of this product
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Default store location of this product
		/// </summary>
		public Guid? DefaultLocationId { get; set; }

		/// <summary>
		/// Navigation property for default location
		/// </summary>
		public Location DefaultLocation { get; set; }

		/// <summary>
		/// Default consume within days of "opening" this item
		/// </summary>
		public TimeSpan? DefaultConsumeWithin { get; set; }

		/// <summary>
		/// Default best-before difference to pre-fill upon adding
		/// </summary>
		public TimeSpan? DefaultBestBefore { get; set; }

		/// <summary>
		/// Barcodes of this product
		/// </summary>
		public List<ProductBarcode> ProductBarcodes { get; set; }

		/// <summary>
		/// Stocked items of this product
		/// </summary>
		public List<StockedItem> StockedItems { get; set; }

		/// <summary>
		/// A factor that allows products to be consumed at 1/[factor] each time
		/// </summary>
		public int? ConsumeFactor { get; set; }
	}
}
