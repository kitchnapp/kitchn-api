using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kitchn.API.GraphQL.Tests.Fixtures;
using Kitchn.API.GraphQL.Tests.Types;
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
		public async Task GetBatteries_ReturnsEmptyList()
		{
			var client = _factory.CreateClient();

			var gqlResponse = await new GraphQLRequest
			{
				Query = "{batteries{id name}}"
			}.Send(client);

			Assert.Null(gqlResponse.Errors);

			var batteries = gqlResponse.Data["batteries"] as JArray;

			Assert.Empty(batteries);
		}

		[Fact]
		public async Task DeleteBattery_NotExist_ThrowsException()
		{
			var client = _factory.CreateClient();

			var gqlResponse = await new GraphQLRequest
			{
				Query = "mutation {battery:deleteBattery(id:\"" + Guid.NewGuid() + "\"){id}}"
			}.Send(client);

			Assert.Null(gqlResponse.Data["battery"].ToObject<object>());
			Assert.NotNull(gqlResponse.Errors);
		}

		[Fact]
		public async Task DeleteBattery_ReturnsBattery()
		{
			var client = _factory.CreateClient();

			var createBatteryResponse = await new GraphQLRequest
			{
				Query = "mutation($battery:BatteryInput!){battery:createBattery(battery:$battery){id}}",
				Variables = new
				{
					battery = new
					{
						name = Guid.NewGuid().ToString()
					}
				}
			}.Send(client);

			Assert.NotNull(createBatteryResponse.Data["battery"].ToObject<object>());
			Assert.Null(createBatteryResponse.Errors);

			var deleteBatteryResponse = await new GraphQLRequest
			{
				Query = "mutation {battery:deleteBattery(id:\"" + createBatteryResponse.Data["battery"].Value<string>("id") + "\"){id}}"
			}.Send(client);

			Assert.NotNull(deleteBatteryResponse.Data["battery"].ToObject<object>());
			Assert.Null(deleteBatteryResponse.Errors);
		}

		[Fact]
		public async Task UpdateBattery_ReturnsBattery()
		{
			var client = _factory.CreateClient();

			var createBatteryResponse = await new GraphQLRequest
			{
				Query = "mutation($battery:BatteryInput!){battery:createBattery(battery:$battery){id}}",
				Variables = new
				{
					battery = new
					{
						name = Guid.NewGuid().ToString()
					}
				}
			}.Send(client);

			Assert.NotNull(createBatteryResponse.Data["battery"].ToObject<object>());
			Assert.Null(createBatteryResponse.Errors);

			var batteryId = createBatteryResponse.Data["battery"].Value<string>("id");
			var newId = Guid.NewGuid().ToString();

			var updateBatteryResponse = await new GraphQLRequest
			{
				Query = "mutation($battery:BatteryInput!){battery:updateBattery(id:\"" + batteryId + "\",battery:$battery){id}}",
				Variables = new
				{
					battery = new
					{
						name = newId
					}
				}
			}.Send(client);

			Assert.NotNull(updateBatteryResponse.Data["battery"].ToObject<object>());
			Assert.Equal(newId, updateBatteryResponse.Data["battery"].Value<string>("name"));
			Assert.Null(updateBatteryResponse.Errors);
		}

		[Fact]
		public async Task UpdateBattery_ThrowsException()
		{
			var client = _factory.CreateClient();

			var gqlResponse = await new GraphQLRequest
			{
				Query = "mutation($battery:BatteryInput!){battery:updateBattery(id:\"" + Guid.NewGuid() + "\",battery:$battery){id}}",
				Variables = new
				{
					battery = new
					{
						name = Guid.NewGuid().ToString()
					}
				}
			}.Send(client);

			Assert.Null(gqlResponse.Data["battery"].ToObject<object>());
			Assert.NotNull(gqlResponse.Errors);
		}

		[Fact]
		public async Task CreateBattery_ReturnsBattery()
		{
			var client = _factory.CreateClient();

			var gqlResponse = await new GraphQLRequest
			{
				Query = "mutation($battery:BatteryInput!){battery:createBattery(battery:$battery){id}}",
				Variables = new
				{
					battery = new
					{
						name = Guid.NewGuid().ToString()
					}
				}
			}.Send(client);

			Assert.NotNull(gqlResponse.Data["battery"].ToObject<object>());
			Assert.Null(gqlResponse.Errors);
		}

		[Fact]
		public async Task CreateBattery_NoName_ThrowsException()
		{
			var client = _factory.CreateClient();

			var gqlResponse = await new GraphQLRequest
			{
				Query = "mutation($battery:BatteryInput!){battery:createBattery(battery:$battery){id}}",
				Variables = new
				{
					battery = new
					{
						location = Guid.NewGuid().ToString()
					}
				}
			}.Send(client);

			Assert.Null(gqlResponse.Data["battery"].ToObject<object>());
			Assert.NotNull(gqlResponse.Errors);
		}
	}
}
