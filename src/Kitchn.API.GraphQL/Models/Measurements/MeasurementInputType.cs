using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.Measurements
{
	public class MeasurementInputType : InputObjectGraphType<Measurement>
	{
		public MeasurementInputType()
		{
			Name = "MeasurementInput";

			Field(x => x.Name, nullable: true).Description("The name of the measurement.");
			Field(x => x.MultipleName, nullable: true).Description("The multiple word of the measurement.");
		}
	}
}