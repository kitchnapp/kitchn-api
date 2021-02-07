using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.RecipeInstructions
{
	public class RecipeInstructionInputType : InputObjectGraphType<RecipeInstruction>
	{
		public RecipeInstructionInputType()
		{
			Name = "RecipeInstructionInput";

			Field(x => x.Instruction, nullable: true).Description("The instruction of the recipe instruction step.");
			Field<IntGraphType>("order", "The order of the recipe instruction.");
		}
	}
}