using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models
{
	public class ChoreType : ObjectGraphType<Chore>
	{
		public ChoreType()
		{
			Name = "Chore";
			Description = "A chore that needs to be accomplished.";

			Field(x => x.Id).Description("The ID of the chore.");
			Field(x => x.Title).Description("The title of the chore.");
			Field(x => x.Description).Description("The description of the chore.");
		}
	}
}