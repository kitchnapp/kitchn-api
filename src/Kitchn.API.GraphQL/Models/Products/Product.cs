using System;

namespace Kitchn.API.GraphQL.Models.Products
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid? DefaultLocationId { get; set; }
		public TimeSpan? DefaultConsumeWithin { get; set; }
		public TimeSpan? DefaultBestBefore { get; set; }
	}
}