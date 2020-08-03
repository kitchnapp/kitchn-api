using Microsoft.EntityFrameworkCore;

namespace Kitchn.Data
{
	/// <summary>
	/// Kitchn Database Context via EF Core
	/// </summary>
	public class KitchnDbContext : DbContext
	{
		/// <summary>
		/// Initialise a db context via options
		/// </summary>
		public KitchnDbContext(DbContextOptions<KitchnDbContext> options)
			: base(options)
		{
		}
	}
}