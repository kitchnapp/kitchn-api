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

			var gqlResponse = await new GraphQLRequest
			{
				Query = "{batteries{id name}}"
			}.Send(client);

			var batteries = gqlResponse["batteries"] as JArray;

			Assert.Empty(batteries);
		}
	}
}
