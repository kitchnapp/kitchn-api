using System;

namespace Kitchn.API.Services.Models
{
	public class RecipeInstruction
	{
		public Guid Id { get; set; }
		public Guid? RecipeId { get; set; }
		public int? Order { get; set; }
		public string Instruction { get; set; }
	}
}