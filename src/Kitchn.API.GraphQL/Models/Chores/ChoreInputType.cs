using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.Chores
{
	public class ChoreInputType : InputObjectGraphType<Chore>
	{
		public ChoreInputType()
		{
			Name = "ChoreInput";

			Field(x => x.Title, nullable: true).Description("The title of the chore.");
			Field(x => x.Description, nullable: true).Description("The description of the chore.");
		}
	}
}