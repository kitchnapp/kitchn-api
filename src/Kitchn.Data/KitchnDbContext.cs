using Kitchn.Data.Models;
using Kitchn.Data.Seeds;
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

		/// <summary>
		/// Setup of relationships and seed data when performing migrations
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Location>().HasData(
				new ReadFromSeed<Location>("Seeds/locations.yaml")
					.GetObjects()
			);

			modelBuilder.Entity<Product>().HasData(
				new ReadFromSeed<Product>("Seeds/products.yaml")
					.GetObjects()
			);

			modelBuilder.Entity<Measurement>().HasData(
				new ReadFromSeed<Measurement>("Seeds/measurements.yaml")
					.GetObjects()
			);

			modelBuilder.Entity<MeasurementConversion>().HasData(
				new ReadFromSeed<MeasurementConversion>("Seeds/measurementConversions.yaml")
					.GetObjects()
			);
		}

		/// <summary>
		/// List of locations
		/// </summary>
		public DbSet<Models.Location> Locations { get; set; }

		/// <summary>
		/// List of products
		/// </summary>
		public DbSet<Models.Product> Products { get; set; }

		/// <summary>
		/// List of measurements
		/// </summary>
		public DbSet<Models.Measurement> Measurements { get; set; }

		/// <summary>
		/// List of measurements
		/// </summary>
		public DbSet<Models.MeasurementConversion> MeasurementConversions { get; set; }

		/// <summary>
		/// List of stocked items
		/// </summary>
		public DbSet<Models.StockedItem> StockedItems { get; set; }
	}
}