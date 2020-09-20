using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.RecipeInstructions
{
	public class RecipeInstructionInputType : InputObjectGraphType<RecipeInstruction>
	{
		public RecipeInstructionInputType()
		{
			Name = "RecipeInstructionInput";

			Field(x => x.Instructions, nullable: true).Description("The instruction of the recipe instruction step.");
			Field<IntGraphType>("order", "The order of the recipe instruction.");
		}
	}
}