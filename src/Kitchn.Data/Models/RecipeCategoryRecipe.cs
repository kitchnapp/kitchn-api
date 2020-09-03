using System;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Recipe category to recipe joining model
	/// </summary>
	public class RecipeCategoryRecipe
	{
		/// <summary>
		/// ID of the recipe category
		/// </summary>
		public Guid RecipeCategoryId { get; set; }

		/// <summary>
		/// Navigation property of the recipe category
		/// </summary>
		public RecipeCategory RecipeCategory { get; set; }

		/// <summary>
		/// ID of the recipe
		/// </summary>
		public Guid RecipeId { get; set; }

		/// <summary>
		/// Navigation property of the recipe
		/// </summary>
		public Recipe Recipe { get; set; }
	}
}
