using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.Recipes
{
	public class RecipeType : ObjectGraphType<Recipe>
	{
		public RecipeType(KitchnDbContext dbContext)
		{
			Name = "Recipe";
			Description = "A recipe to follow to make a meal.";

			Field(x => x.Id).Description("The ID of the recipe.");
			Field(x => x.Name).Description("The name of the recipe.");
			Field(x => x.Description).Description("The description of the recipe.");
			Field<IntGraphType>("rating", "The rating of the recipe.");

			Field<ListGraphType<RecipeCategories.RecipeCategoryType>>("categories", "The categories of the recipe.",
				resolve: context =>
				{
					return dbContext.Recipes
						.Include(o => o.Categories)
						.Where(q => q.Id == context.Source.Id)
						.SelectMany(recipe => recipe.Categories)
						.Select(categoryLink => new RecipeCategories.RecipeCategory
						{
							Id = categoryLink.RecipeCategory.Id,
							Name = categoryLink.RecipeCategory.Name
						});
				}
			);
		}
	}
}