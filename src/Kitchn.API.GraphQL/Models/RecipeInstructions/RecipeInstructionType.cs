using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.RecipeInstructions
{
	public class RecipeInstructionType : ObjectGraphType<RecipeInstruction>
	{
		public RecipeInstructionType(KitchnDbContext dbContext, IMapper mapper)
		{
			Name = "RecipeInstruction";
			Description = "A instruction for a recipe.";

			Field(x => x.Id).Description("The ID of the recipe instruction.");
			Field<IntGraphType>("order", "The order of the recipe instruction.");
			Field(x => x.Instruction).Description("The instruction of the step.");

			Field<Models.Recipes.RecipeType>("recipe", "The recipe for this instruction.",
				resolve: context =>
				{
					return mapper.Map<Recipe>(
						dbContext.Recipes
							.Where(q => q.Id == context.Source.RecipeId)
							.FirstOrDefault()
					);
				}
			);
		}
	}
}