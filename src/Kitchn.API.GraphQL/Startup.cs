using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kitchn.API.GraphQL.Models;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.Server.Ui.Voyager;
using Microsoft.Extensions.Logging;
using GraphQL.Server.Ui.Playground;
using Kitchn.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.AspNetCore.CookiePolicy;
using Kitchn.API.Services.Repositories;
using Kitchn.API.Services.Interfaces;
using Kitchn.API.Services.Models;

namespace Kitchn.API.GraphQL
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod();
					});

				options.AddPolicy("AllowSpecific",
					builder =>
					{
						var origins = Configuration["Cors:Origins"].Split(";");

						builder
							.WithOrigins(origins)
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});

			services.AddDbContext<KitchnDbContext>(options =>
				options.UseNpgsql(Configuration["ConnectionStrings:KitchnDb"])
			);

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<KitchnDbContext>()
				.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings
				options.Cookie.HttpOnly = false;
				options.Cookie.SecurePolicy = CookieSecurePolicy.None;
				options.SlidingExpiration = true;
			});

			services.AddAuthentication();
			services.AddAuthorization();

			services.AddScoped<KitchnQuery>();
			services.AddScoped<KitchnMutation>();
			services.AddScoped<KitchnSchema>();

			services.AddScoped<IRepository<Battery>, BatteryRepository>();
			services.AddScoped<IRepository<Chore>, ChoreRepository>();
			services.AddScoped<IRepository<Location>, LocationRepository>();
			services.AddScoped<IRepository<StockedItem>, StockedItemRepository>();

			services
				.AddGraphQL((options, provider) =>
				{
					options.EnableMetrics = true;
					var logger = provider.GetRequiredService<ILogger<Startup>>();
					options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occured", ctx.OriginalException.Message);
				})
				.AddGraphTypes(ServiceLifetime.Scoped)
				.AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }) // For .NET Core 3+
				.AddDataLoader() // Add required services for DataLoader support
				.AddGraphTypes(typeof(KitchnSchema))
				.AddGraphQLAuthorization();

			services.AddAutoMapper(typeof(Startup));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(Configuration["Cors:Policy"]);

			app.UseAuthorization();
			app.UseAuthentication();

			app.UseWebSockets();

			app.UseGraphQL<KitchnSchema>("/graphql");

			if (Configuration.GetValue<bool>("GraphQL:Altair"))
			{
				// use altair middleware at default url /ui/altair
				app.UseGraphQLAltair(new GraphQLAltairOptions());
			}

			if (Configuration.GetValue<bool>("GraphQL:Playground"))
			{
				// use graphql-playground middleware at default url /ui/playground
				app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
			}

			if (Configuration.GetValue<bool>("GraphQL:Voyager"))
			{
				// use graphql-playground middleware at default url /ui/voyager
				app.UseGraphQLVoyager(new GraphQLVoyagerOptions());
			}

			if (true)
			{
				var optionsBuilder = new DbContextOptionsBuilder<KitchnDbContext>();
				optionsBuilder.UseNpgsql(Configuration["ConnectionStrings:KitchnDb"]);

				ApplyMigrations(new KitchnDbContext(optionsBuilder.Options));
			}
		}

		public void ApplyMigrations(KitchnDbContext context)
		{
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
		}
	}
}