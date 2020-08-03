using System;

namespace Kitchn.Data.Models
{
	/// <summary>
	/// Recipe category model
	/// </summary>
	public class RecipeCategory
	{
		/// <summary>
		/// ID of this recipe category
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of this recipe category
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Parent of this recipe category ID
		/// Can be null to indicate top-level recipe category
		/// </summary>
		public Guid? RecipeCategoryId { get; set; }
	}
}
