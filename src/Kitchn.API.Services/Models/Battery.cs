using System;

namespace Kitchn.API.Services.Models
{
	public class Battery
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string Type { get; set; }
		public DateTime? LastCharged { get; set; }
		public bool? Rechargeable { get; set; }
		public DateTime? ExpiryDate { get; set; }
	}
}