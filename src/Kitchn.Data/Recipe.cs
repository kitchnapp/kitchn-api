using System;

namespace Kitchn.Data
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
		/// Instruction Id's of this recipe
		/// </summary>
		public List<Guid> RecipeInstructionIds { get; set; }
	}
}
