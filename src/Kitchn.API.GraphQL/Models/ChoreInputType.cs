using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models
{
	public class ChoreInputType : InputObjectGraphType<Chore>
	{
		public ChoreInputType()
		{
			Name = "ChoreInput";

			Field(x => x.Title).Description("The title of the chore.");
			Field(x => x.Description).Description("The description of the chore.");
		}
	}
}