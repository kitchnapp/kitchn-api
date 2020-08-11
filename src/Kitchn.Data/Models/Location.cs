using System;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Location model
	/// </summary>
	public class Location
	{
		/// <summary>
		/// ID of this location
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of this location
		/// </summary>
		public string Name { get; set; }
	}
}
