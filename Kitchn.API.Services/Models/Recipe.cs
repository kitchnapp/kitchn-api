using System;

namespace Kitchn.API.Services.Models
{
	public class Recipe
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int? Rating { get; set; }
	}
}