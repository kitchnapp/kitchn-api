using System;

namespace Kitchn.API.GraphQL.Models.MeasurementConversions
{
	public class MeasurementConversion
	{
		public Guid Id { get; set; }
		public Guid FromMeasurementId { get; set; }
		public Guid ToMeasurementId { get; set; }
		public decimal Factor { get; set; }
	}
}