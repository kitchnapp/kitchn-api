using System;

namespace Kitchn.API.Services.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid? DefaultLocationId { get; set; }
		public TimeSpan? DefaultConsumeWithin { get; set; }
		public TimeSpan? DefaultBestBefore { get; set; }
		public int? ConsumeFactor { get; set; }
		public Guid? IndividualMeasurementId { get; set; }
		public Guid? GroupMeasurementId { get; set; }
	}
}