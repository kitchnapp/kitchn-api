using System;

namespace Kitchn.API.GraphQL.Models.Chores
{
	public class Chore
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}