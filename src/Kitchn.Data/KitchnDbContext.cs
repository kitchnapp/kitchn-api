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
		/// Add option to seed data on model create
		/// </summary>
		public bool Seed { get; set; }

		/// <summary>
		/// Initialise a db context via options
		/// </summary>
		public KitchnDbContext(DbContextOptions<KitchnDbContext> options, bool seed = false)
			: base(options)
		{
			Seed = seed;
		}

		/// <summary>
		/// Setup of relationships and seed data when performing migrations
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			if (Seed)
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

				modelBuilder.Entity<Chore>().HasData(
					new ReadFromSeed<Chore>("Seeds/chores.yaml")
						.GetObjects()
				);

				modelBuilder.Entity<RecipeCategory>().HasData(
					new ReadFromSeed<RecipeCategory>("Seeds/recipeCategories.yaml")
						.GetObjects()
				);
			}
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

		/// <summary>
		/// List of chores
		/// </summary>
		public DbSet<Models.Chore> Chores { get; set; }

		/// <summary>
		/// List of chores
		/// </summary>
		public DbSet<Models.RecipeCategory> RecipeCategories { get; set; }
	}
}