using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kitchn.API.GraphQL.Models;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using Microsoft.Extensions.Logging;
using GraphQL.Server.Ui.Playground;
using Kitchn.Data;
using Microsoft.EntityFrameworkCore;

namespace Kitchn.API.GraphQL
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<KitchnDbContext>(options =>
				options.UseSqlite("Data Source=test.db")
			);

			services.AddScoped<ChoreInputType>();
			services.AddScoped<ChoreType>();
			services.AddScoped<LocationInputType>();
			services.AddScoped<LocationType>();
			services.AddScoped<MeasurementInputType>();
			services.AddScoped<MeasurementType>();
			services.AddScoped<ProductType>();
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
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseWebSockets();

			app.UseGraphQL<KitchnSchema>("/graphql");

			// use altair middleware at default url /ui/altair
			app.UseGraphQLAltair(new GraphQLAltairOptions());

			// use graphql-playground middleware at default url /ui/playground
			app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
		}
	}
}
