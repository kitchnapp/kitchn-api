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
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using AutoMapper;

namespace Kitchn.API.GraphQL
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

			services.AddScoped<KitchnQuery>();
			services.AddScoped<KitchnMutation>();
			services.AddScoped<KitchnSchema>();

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
				.AddGraphTypes(typeof(KitchnSchema));

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
		}
	}
}