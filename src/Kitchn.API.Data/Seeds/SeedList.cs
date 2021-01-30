using System.Collections.Generic;

namespace Kitchn.API.Data.Seeds
{
	/// <summary>
	/// List of a generic set of items stored in a seed object
	/// </summary>
	public class SeedList<T>
	{
		/// <summary>
		/// List of the generic set of items
		/// </summary>
		public List<T> Items { get; set; }
	}
}