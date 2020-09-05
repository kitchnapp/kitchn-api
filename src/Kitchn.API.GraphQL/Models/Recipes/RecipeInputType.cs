using GraphQL;
using GraphQL.Types;

namespace Kitchn.API.GraphQL.Models.Recipes
{
	public class RecipeInputType : InputObjectGraphType<Recipe>
	{
		public RecipeInputType()
		{
			Name = "RecipeInput";

			Field(x => x.Name, nullable: true).Description("The name of the recipe.");
			Field(x => x.Description, nullable: true).Description("The description of the recipe.");
			Field<IntGraphType>("rating", "The rating of the recipe.");
		}
	}
}