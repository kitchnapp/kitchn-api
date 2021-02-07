using GraphQL;
using GraphQL.Types;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL.Models.RecipeCategories
{
	public class RecipeCategoryInputType : InputObjectGraphType<RecipeCategory>
	{
		public RecipeCategoryInputType()
		{
			Name = "RecipeCategoryInput";

			Field(x => x.Name, nullable: true).Description("The name of the recipe category.");
		}
	}
}