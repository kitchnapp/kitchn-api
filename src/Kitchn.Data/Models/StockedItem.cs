using System;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Stocked item model
	/// </summary>
	public class StockedItem
	{
		/// <summary>
		/// Id of the stocked item
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Product ID of the item stocked
		/// </summary>
		public Guid ProductId { get; set; }

		/// <summary>
		/// Navigation property for the product of this stock
		/// </summary>
		public Product Product { get; set; }

		/// <summary>
		/// Current location of this stocked item
		/// </summary>
		public Guid LocationId { get; set; }

		/// <summary>
		/// Navigation property for the location of this stock
		/// </summary>
		public Location Location { get; set; }

		/// <summary>
		/// Latest expiry date for this stocked item
		/// </summary>
		public DateTime? ExpiryDate { get; set; }

		/// <summary>
		/// Day this stocked item was opened. If this value is not null, it is considered open.
		/// </summary>
		public DateTime? OpenedDate { get; set; }
	}
}
