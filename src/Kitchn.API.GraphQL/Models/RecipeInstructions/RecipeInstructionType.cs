using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.RecipeInstructions
{
	public class RecipeInstructionType : ObjectGraphType<RecipeInstruction>
	{
		public RecipeInstructionType(KitchnDbContext dbContext)
		{
			Name = "RecipeInstruction";
			Description = "A instruction for a recipe.";

			Field(x => x.Id).Description("The ID of the recipe instruction.");
			Field<IntGraphType>("order", "The order of the recipe instruction.");
			Field(x => x.Instructions).Description("The instruction of the step.");

			Field<Models.Recipes.RecipeType>("recipe", "The recipe for this instruction.",
				resolve: context =>
				{
					return dbContext.Recipes
						.Where(q => q.Id == context.Source.RecipeId)
						.Select(recipe => new Recipes.Recipe
						{
							Id = recipe.Id,
							Name = recipe.Name,
							Description = recipe.Description,
							Rating = recipe.Rating
						})
						.FirstOrDefault();
				}
			);
		}
	}
}