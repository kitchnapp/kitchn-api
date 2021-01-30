using System;
using System.Linq;
using Kitchn.API.GraphQL;
using Kitchn.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kitchn.API.GraphQL.Tests.Fixtures
{
	public class MemoryStorageFixture<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureTestServices(services =>
			{
				var descriptor = services.SingleOrDefault(
					d => d.ServiceType ==
						typeof(DbContextOptions<KitchnDbContext>));

				if (descriptor != null)
				{
					services.Remove(descriptor);
				}

				services.AddDbContext<KitchnDbContext>((options, context) =>
				{
					context.UseInMemoryDatabase("KitchnTestDb");
				});
			});
		}
	}
}