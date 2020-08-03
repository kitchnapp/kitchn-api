using System;

namespace Kitchn.Data
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
		public Guid DefaultProductLocationId { get; set; }
	}
}
