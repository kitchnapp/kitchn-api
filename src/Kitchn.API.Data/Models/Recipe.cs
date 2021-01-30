using System;
using System.Collections.Generic;

namespace Kitchn.API.Data.Models
{
	/// <summary>
	/// Recipe model
	/// </summary>
	public class Recipe
	{
		/// <summary>
		/// ID of this recipe
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of this recipe
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Description of this recipe
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Instruction's of this recipe
		/// </summary>
		public List<RecipeInstruction> RecipeInstructions { get; set; }

		/// <summary>
		/// Categories of this recipe
		/// </summary>
		public List<RecipeCategoryRecipe> Categories { get; set; }

		/// <summary>
		/// Rating of this recipe
		/// </summary>
		public int? Rating { get; set; }
	}
}
