using System;

namespace Kitchn.API.Data.Models
{
	/// <summary>
	/// Measurement Conversions model
	/// </summary>
	public class MeasurementConversion
	{
		/// <summary>
		/// ID of this measurement conversion
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// From Measurement ID
		/// </summary>
		public Guid FromMeasurementId { get; set; }

		/// <summary>
		/// Navigation property for From Measurement
		/// </summary>
		public Measurement FromMeasurement { get; set; }

		/// <summary>
		/// To Measurement ID
		/// </summary>
		public Guid ToMeasurementId { get; set; }

		/// <summary>
		/// Navigation property for To Measurement
		/// </summary>
		public Measurement ToMeasurement { get; set; }

		/// <summary>
		/// Factor between the measurements to go from one measurement to the other
		/// </summary>
		public decimal Factor { get; set; }

		/// <summary>
		/// Calculate the to-measurement value
		/// </summary>
		public decimal Calculate(decimal fromMeasurementValue)
		{
			return fromMeasurementValue * Factor;
		}

		/// <summary>
		/// Calculate the reverse from-measurement value
		/// </summary>
		public decimal ReverseCalculate(decimal toMeasurementValue)
		{
			return toMeasurementValue / Factor;
		}
	}
}
