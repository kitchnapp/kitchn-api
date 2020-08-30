using System;

namespace Kitchn.API.GraphQL.Models
{
	public class Measurement
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string MultipleName { get; set; }
	}
}