using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.RecipeCategories
{
	public class RecipeCategoryType : ObjectGraphType<RecipeCategory>
	{
		public RecipeCategoryType(KitchnDbContext dbContext, IMapper mapper)
		{
			Name = "RecipeCategory";
			Description = "A category to organise recipes.";

			Field(x => x.Id).Description("The ID of the recipe category.");
			Field(x => x.Name).Description("The name of the recipe category.");

			Field<ListGraphType<Models.Recipes.RecipeType>>("recipes", "The recipes in this category.",
				resolve: context =>
				{
					return mapper.Map<IEnumerable<Recipes.Recipe>>(
						dbContext.Recipes
							.Include(q => q.Categories)
							.Where(q => q.Categories.Where(q => q.RecipeCategoryId == context.Source.Id).Any())
					);
				}
			);
		}
	}
}