using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using Kitchn.API.GraphQL.Models;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.Extensions.Logging;
using GraphQL.Server.Ui.Playground;

namespace Kitchn.API.GraphQL
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ProductType>();
			services.AddSingleton<KitchnQuery>();
			services.AddSingleton<KitchnSchema>();

			services
				.AddGraphQL((options, provider) =>
				{
					options.EnableMetrics = true;
					var logger = provider.GetRequiredService<ILogger<Startup>>();
					options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occured", ctx.OriginalException.Message);
				})
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
