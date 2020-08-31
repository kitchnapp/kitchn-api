using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;

namespace Kitchn.API.GraphQL.Models.RecipeCategories
{
	public class RecipeCategoryType : ObjectGraphType<RecipeCategory>
	{
		public RecipeCategoryType(KitchnDbContext dbContext)
		{
			Name = "RecipeCategory";
			Description = "A category to organise recipes.";

			Field(x => x.Id).Description("The ID of the recipe category.");
			Field(x => x.Name).Description("The name of the recipe category.");
		}
	}
}