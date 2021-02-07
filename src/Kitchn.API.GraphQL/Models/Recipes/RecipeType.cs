using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Kitchn.API.Data;
using Kitchn.API.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL.Models.Recipes
{
	public class RecipeType : ObjectGraphType<Recipe>
	{
		public RecipeType(KitchnDbContext dbContext, IMapper mapper)
		{
			Name = "Recipe";
			Description = "A recipe to follow to make a meal.";

			Field(x => x.Id).Description("The ID of the recipe.");
			Field(x => x.Name).Description("The name of the recipe.");
			Field(x => x.Description).Description("The description of the recipe.");
			Field<IntGraphType>("rating", "The rating of the recipe.");

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<RecipeCategories.RecipeCategoryType>>>>("categories", "The categories of the recipe.",
				resolve: context =>
				{
					return mapper.Map<RecipeCategory>(
						dbContext.Recipes
							.Include(o => o.Categories)
							.Where(q => q.Id == context.Source.Id)
							.SelectMany(recipe => recipe.Categories)
							.Select(categoryLink => categoryLink.RecipeCategory)
					);
				}
			);

			Field<NonNullGraphType<ListGraphType<NonNullGraphType<RecipeInstructions.RecipeInstructionType>>>>("instructions", "The instructions of the recipe.",
				resolve: context =>
				{
					return mapper.Map<IEnumerable<RecipeInstruction>>(
						dbContext.RecipeInstructions
							.Where(q => q.RecipeId == context.Source.Id)
					);
				}
			);
		}
	}
}