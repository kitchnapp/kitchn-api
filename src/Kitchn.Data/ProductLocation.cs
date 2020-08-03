using System;

namespace Kitchn.Data
{
	/// <summary>
	/// Product Location model
	/// </summary>
	public class ProductLocation
	{
		/// <summary>
		/// ID of this product location
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of this product location
		/// </summary>
		public string Name { get; set; }
	}
}
