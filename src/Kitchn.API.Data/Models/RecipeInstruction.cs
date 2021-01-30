using System;

namespace Kitchn.API.Data.Models
{
	/// <summary>
	/// Recipe instruction model
	/// </summary>
	public class RecipeInstruction
	{
		/// <summary>
		/// ID of this recipe instruction
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Parent recipe ID
		/// </summary>
		public Guid RecipeId { get; set; }

		/// <summary>
		/// Navigation property for the recipe
		/// </summary>
		public Recipe Recipe { get; set; }

		/// <summary>
		/// Order placement of this recipe instruction. 1 is first, 999 is last.
		/// </summary>
		public int Order { get; set; }

		/// <summary>
		/// The instruction that the user must do
		/// </summary>
		public string Instruction { get; set; }
	}
}
