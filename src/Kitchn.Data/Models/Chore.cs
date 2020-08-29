using System;

namespace Kitchn.Data.Models
{
	public class Chore
	{
		/// <summary>
		/// ID of this chore
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Name of the chore
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Optional description of the chore
		/// </summary>
		public string Description { get; set; }
	}
}