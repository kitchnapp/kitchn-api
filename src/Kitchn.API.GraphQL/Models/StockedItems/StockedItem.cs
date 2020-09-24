using System;

namespace Kitchn.API.GraphQL.Models.StockedItems
{
	public class StockedItem
	{
		public Guid Id { get; set; }
		public Guid? ProductId { get; set; }
		public Guid? LocationId { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public DateTime? OpenedDate { get; set; }
		public int? ConsumedCount { get; set; }
	}
}