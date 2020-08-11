using System;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Product Measurement model.
	/// Extends onto the product model.
	/// </summary>
	public class ProductMeasurement
	{
		/// <summary>
		/// ID of this product
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Individual measurement ID of this product
		/// </summary>
		public Guid IndividualMeasurementId { get; set; }

		/// <summary>
		/// Group measurement ID of this product
		/// For example, 8 rashers of bacon becomes a pack
		/// </summary>
		public Guid? GroupMeasurementId { get; set; }

		/// <summary>
		/// Custom factor for converting between the group and individual measurements
		/// </summary>
		public int? Factor { get; set; }
	}
}