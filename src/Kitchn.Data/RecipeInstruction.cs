using System;

namespace Kitchn.Data
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
		/// Order placement of this recipe instruction. 1 is first, 999 is last.
		/// </summary>
		public int Order { get; set; }

		/// <summary>
		/// The instruction that the user must do
		/// </summary>
		public string Instruction { get; set; }
	}
}
