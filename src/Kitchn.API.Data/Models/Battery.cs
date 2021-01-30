using System;

namespace Kitchn.API.Data.Models
{
	public class Battery
	{
		/// <summary>
		/// ID of this battery
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of the battery
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Where this battery currently is situated
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Battery type
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Last charged
		/// </summary>
		public DateTime? LastCharged { get; set; }

		/// <summary>
		/// Whether it is a rechargeable battery
		/// </summary>
		public bool? Rechargeable { get; set; }

		/// <summary>
		/// Some batteries have an expiry date on them
		/// </summary>
		public DateTime? ExpiryDate { get; set; }
	}
}