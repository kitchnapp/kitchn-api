using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.Measurements
{
	public class MeasurementType : ObjectGraphType<Measurement>
	{
		public MeasurementType()
		{
			Name = "Measurement";
			Description = "A measurement which a product can be measured in.";

			Field(x => x.Id).Description("The ID of the measurement.");
			Field(x => x.Name).Description("The name of the measurement.");
			Field(x => x.MultipleName, nullable: true).Description("The multiple word of the measurement.");
		}
	}
}