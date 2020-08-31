using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.Recipes
{
	public class RecipeType : ObjectGraphType<Recipe>
	{
		public RecipeType()
		{
			Name = "Recipe";
			Description = "A recipe to follow to make a meal.";

			Field(x => x.Id).Description("The ID of the recipe.");
			Field(x => x.Name).Description("The name of the recipe.");
			Field(x => x.Description).Description("The description of the recipe.");
			Field<IntGraphType>("rating", "The rating of the recipe.");
		}
	}
}