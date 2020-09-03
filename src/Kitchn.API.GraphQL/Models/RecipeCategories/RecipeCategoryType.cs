using System.Linq;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

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

			Field<ListGraphType<Models.Recipes.RecipeType>>("recipes", "The recipes in this category.",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "search" }
				),
				resolve: context =>
				{
					var search = context.GetArgument<string>("search");

					return dbContext.Recipes
							.Include(q => q.Categories)
							.Where(q => q.Name.Contains(search) || search == null)
							.Where(q => q.Categories.Where(q => q.RecipeCategoryId == context.Source.Id).Any())
							.Select(recipe => new Recipes.Recipe
							{
								Id = recipe.Id,
								Name = recipe.Name,
								Description = recipe.Description,
								Rating = recipe.Rating
							});
				}
			);
		}
	}
}