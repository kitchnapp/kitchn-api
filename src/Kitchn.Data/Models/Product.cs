using System;

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
		/// Default consume within days of "opening" this item
		/// </summary>
		public TimeSpan? DefaultConsumeWithinDays { get; set; }

		/// <summary>
		/// Default best-before difference to pre-fill upon adding
		/// </summary>
		public TimeSpan? DefaultBestBeforeDateDifference { get; set; }
	}
}
