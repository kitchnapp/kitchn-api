using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kitchn.Data
{
	public class KitchnContextFactory : IDesignTimeDbContextFactory<KitchnDbContext>
	{
		public KitchnDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<KitchnDbContext>();
			optionsBuilder.UseSqlite("Data Source=test.db");

			return new KitchnDbContext(optionsBuilder.Options);
		}
	}
}