using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kitchn.API.GraphQL.Tests.Fixtures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Kitchn.API.GraphQL.Tests
{
	public class BatteryTests : IClassFixture<MemoryStorageFixture<Startup>>
	{
		private readonly MemoryStorageFixture<Startup> _factory;

		public BatteryTests(MemoryStorageFixture<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task GetBatteries_Empty()
		{
			var client = _factory.CreateClient();

			var graphQLQuery = new
			{
				query = "{batteries{id name}}"
			};

			var jsonQuery = JsonConvert.SerializeObject(graphQLQuery);
			var stringContent = new StringContent(jsonQuery, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("/graphql", stringContent);

			var gqlResponse = JObject.Parse(await response.Content.ReadAsStringAsync())["data"];

			var batteries = gqlResponse["batteries"] as JArray;

			Assert.Empty(batteries);
		}
	}
}
