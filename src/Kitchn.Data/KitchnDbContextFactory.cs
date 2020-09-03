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
			optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=password");

			return new KitchnDbContext(optionsBuilder.Options, seed: true);
		}
	}
}