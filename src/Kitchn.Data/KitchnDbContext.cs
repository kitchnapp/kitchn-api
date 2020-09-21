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
		public KitchnDbContextOptions KitchnDbContextOptions { get; set; }

		/// <summary>
		/// Initialise a db context via options
		/// </summary>
		public KitchnDbContext(DbContextOptions<KitchnDbContext> options)
			: base(options)
		{
		}

		public KitchnDbContext(DbContextOptions<KitchnDbContext> options, KitchnDbContextOptions kitchnOptions = null)
			: this(options)
		{
			KitchnDbContextOptions = kitchnOptions;
		}

		/// <summary>
		/// Setup of relationships and seed data when performing migrations
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RecipeCategoryRecipe>()
				.HasKey(t => new { t.RecipeId, t.RecipeCategoryId });

			modelBuilder.Entity<RecipeCategoryRecipe>()
				.HasOne(pt => pt.Recipe)
				.WithMany(p => p.Categories)
				.HasForeignKey(pt => pt.RecipeId);

			modelBuilder.Entity<RecipeCategoryRecipe>()
				.HasOne(pt => pt.RecipeCategory)
				.WithMany(t => t.Recipes)
				.HasForeignKey(pt => pt.RecipeCategoryId);

			if (KitchnDbContextOptions?.Seed ?? false)
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
		/// List of product barcodes
		/// </summary>
		public DbSet<Models.ProductBarcode> ProductBarcodes { get; set; }

		/// <summary>
		/// List of products
		/// </summary>
		public DbSet<Models.ProductMeasurement> ProductMeasurements { get; set; }

		/// <summary>
		/// List of measurements
		/// </summary>
		public DbSet<Models.Measurement> Measurements { get; set; }

		/// <summary>
		/// List of measurement conversions
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
		/// List of recipe categories
		/// </summary>
		public DbSet<Models.RecipeCategory> RecipeCategories { get; set; }

		/// <summary>
		/// List of recipes
		/// </summary>
		public DbSet<Models.Recipe> Recipes { get; set; }

		/// <summary>
		/// List of recipe instructions
		/// </summary>
		public DbSet<Models.RecipeInstruction> RecipeInstructions { get; set; }

		/// <summary>
		/// List of batteries
		/// </summary>
		public DbSet<Models.Battery> Batteries { get; set; }
	}
}