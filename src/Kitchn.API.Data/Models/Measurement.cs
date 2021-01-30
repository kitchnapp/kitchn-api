using System;

namespace Kitchn.API.Data.Models
{
	/// <summary>
	/// Measurement model
	/// </summary>
	public class Measurement
	{
		/// <summary>
		/// ID of this measurement
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of this measurement
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Multiple name. If this value is null, it will append "s" to Name
		/// </summary>
		public string MultipleName { get; set; }
	}
}
