using System;

namespace Kitchn.API.Services.Models
{
	public class Chore
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}