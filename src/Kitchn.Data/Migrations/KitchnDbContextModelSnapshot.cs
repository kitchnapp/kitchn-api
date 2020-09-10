﻿// <auto-generated />
using System;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kitchn.Data.Migrations
{
    [DbContext(typeof(KitchnDbContext))]
    partial class KitchnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kitchn.Data.Models.Chore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Chores");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b7ee657-1ffb-4d78-b6ef-a9f2c1506f8b"),
                            Title = "Make Bed"
                        },
                        new
                        {
                            Id = new Guid("d99e4d54-934e-47ea-b5ec-135eb59f83ae"),
                            Title = "Clean Oven"
                        },
                        new
                        {
                            Id = new Guid("38da484f-6d6d-4a2e-afc3-5f55f1a282a0"),
                            Title = "Empty Bins"
                        });
                });

            modelBuilder.Entity("Kitchn.Data.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("34aef97c-1b6b-4c5e-a33b-38739515de70"),
                            Name = "Refrigerator"
                        },
                        new
                        {
                            Id = new Guid("c289df2f-05af-4c9f-986e-6ce4ca304e5f"),
                            Name = "Freezer"
                        },
                        new
                        {
                            Id = new Guid("c8154b38-0004-4930-bcf7-18365bd541b1"),
                            Name = "Cupboard"
                        },
                        new
                        {
                            Id = new Guid("d9963f65-ef83-4659-b8a1-fce5a445012a"),
                            Name = "Spice Rack"
                        });
                });

            modelBuilder.Entity("Kitchn.Data.Models.Measurement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MultipleName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Measurements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3ecc9b2c-caf5-4bab-984d-bdd8ba0082ea"),
                            Name = "Gram"
                        },
                        new
                        {
                            Id = new Guid("d38c4b90-dddf-4c0c-9369-4cc1bc474690"),
                            Name = "Kilogram"
                        },
                        new
                        {
                            Id = new Guid("a3a2049c-1f95-4d37-abaa-5122b3e88be4"),
                            Name = "Slice"
                        },
                        new
                        {
                            Id = new Guid("25831fc7-be30-4676-8a07-cccf2d7c576b"),
                            Name = "Rasher"
                        },
                        new
                        {
                            Id = new Guid("56c60917-f902-4657-9cc7-81eabb1315ae"),
                            Name = "Bottle"
                        },
                        new
                        {
                            Id = new Guid("6adb2348-5305-45b0-a275-6f8bfa1e3131"),
                            Name = "Millilitre"
                        },
                        new
                        {
                            Id = new Guid("988c6634-beec-4e86-94f3-0970cc64ae35"),
                            Name = "Litre"
                        });
                });

            modelBuilder.Entity("Kitchn.Data.Models.MeasurementConversion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Factor")
                        .HasColumnType("numeric");

                    b.Property<Guid>("FromMeasurementId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ToMeasurementId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FromMeasurementId");

                    b.HasIndex("ToMeasurementId");

                    b.ToTable("MeasurementConversions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a743c8f6-f33d-435f-b186-6c00ecaf66f6"),
                            Factor = 1000m,
                            FromMeasurementId = new Guid("3ecc9b2c-caf5-4bab-984d-bdd8ba0082ea"),
                            ToMeasurementId = new Guid("d38c4b90-dddf-4c0c-9369-4cc1bc474690")
                        },
                        new
                        {
                            Id = new Guid("8734caa2-d576-4644-a5fa-6cc4b783c0b3"),
                            Factor = 1000m,
                            FromMeasurementId = new Guid("6adb2348-5305-45b0-a275-6f8bfa1e3131"),
                            ToMeasurementId = new Guid("988c6634-beec-4e86-94f3-0970cc64ae35")
                        });
                });

            modelBuilder.Entity("Kitchn.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan?>("DefaultBestBeforeDateDifference")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("DefaultConsumeWithinDays")
                        .HasColumnType("interval");

                    b.Property<Guid?>("DefaultLocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DefaultLocationId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("07e8aeac-8ab2-489c-a1e4-2846ef9fc680"),
                            Name = "Table Salt"
                        },
                        new
                        {
                            Id = new Guid("31b912cc-b3e1-48da-a5f3-a402c56ecd25"),
                            Name = "Black Pepper"
                        });
                });

            modelBuilder.Entity("Kitchn.Data.Models.ProductBarcode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBarcodes");
                });

            modelBuilder.Entity("Kitchn.Data.Models.ProductMeasurement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Factor")
                        .HasColumnType("integer");

                    b.Property<Guid?>("GroupMeasurementId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IndividualMeasurementId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ProductMeasurements");
                });

            modelBuilder.Entity("Kitchn.Data.Models.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Kitchn.Data.Models.RecipeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("RecipeCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("198a4027-b147-4c84-a179-774a98852053"),
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = new Guid("ea5d7b4d-29f9-4b5a-aa0b-5324ca937712"),
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = new Guid("9aa4eec1-502c-49ae-adc0-8e9cca5250e0"),
                            Name = "Breakfast"
                        });
                });

            modelBuilder.Entity("Kitchn.Data.Models.RecipeCategoryRecipe", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RecipeCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("RecipeId", "RecipeCategoryId");

                    b.HasIndex("RecipeCategoryId");

                    b.ToTable("RecipeCategoryRecipe");
                });

            modelBuilder.Entity("Kitchn.Data.Models.RecipeInstruction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Instruction")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeInstructions");
                });

            modelBuilder.Entity("Kitchn.Data.Models.StockedItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("OpenedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProductId");

                    b.ToTable("StockedItems");
                });

            modelBuilder.Entity("Kitchn.Data.Models.MeasurementConversion", b =>
                {
                    b.HasOne("Kitchn.Data.Models.Measurement", "FromMeasurement")
                        .WithMany()
                        .HasForeignKey("FromMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kitchn.Data.Models.Measurement", "ToMeasurement")
                        .WithMany()
                        .HasForeignKey("ToMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kitchn.Data.Models.Product", b =>
                {
                    b.HasOne("Kitchn.Data.Models.Location", "DefaultLocation")
                        .WithMany()
                        .HasForeignKey("DefaultLocationId");
                });

            modelBuilder.Entity("Kitchn.Data.Models.ProductBarcode", b =>
                {
                    b.HasOne("Kitchn.Data.Models.Product", "Product")
                        .WithMany("ProductBarcodes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kitchn.Data.Models.RecipeCategoryRecipe", b =>
                {
                    b.HasOne("Kitchn.Data.Models.RecipeCategory", "RecipeCategory")
                        .WithMany("Recipes")
                        .HasForeignKey("RecipeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kitchn.Data.Models.Recipe", "Recipe")
                        .WithMany("Categories")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kitchn.Data.Models.RecipeInstruction", b =>
                {
                    b.HasOne("Kitchn.Data.Models.Recipe", "Recipe")
                        .WithMany("RecipeInstructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kitchn.Data.Models.StockedItem", b =>
                {
                    b.HasOne("Kitchn.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kitchn.Data.Models.Product", "Product")
                        .WithMany("StockedItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
