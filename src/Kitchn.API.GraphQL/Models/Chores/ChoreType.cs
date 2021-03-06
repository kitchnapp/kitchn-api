using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.Chores
{
	public class ChoreType : ObjectGraphType<Chore>
	{
		public ChoreType()
		{
			Name = "Chore";
			Description = "A chore that needs to be accomplished.";

			Field(x => x.Id).Description("The ID of the chore.");
			Field(x => x.Title).Description("The title of the chore.");
			Field(x => x.Description, nullable: true).Description("The description of the chore.");
		}
	}
}