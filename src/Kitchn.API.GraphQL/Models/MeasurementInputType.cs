using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models
{
	public class MeasurementInputType : InputObjectGraphType<Measurement>
	{
		public MeasurementInputType()
		{
			Name = "MeasurementInput";

			Field(x => x.Name).Description("The name of the measurement.");
			Field(x => x.MultipleName).Description("The multiple word of the measurement.");
		}
	}
}