using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kitchn.API.GraphQL.Tests
{
	public class GraphQLRequest
	{
		[JsonProperty("query")]
		public string Query { get; set; }

		private StringContent GetRequest()
		{
			var jsonQuery = JsonConvert.SerializeObject(this);
			var stringContent = new StringContent(jsonQuery, Encoding.UTF8, "application/json");

			return stringContent;
		}

		public async Task<JToken> Send(HttpClient client)
		{
			var response = await client.PostAsync("/graphql", GetRequest());

			var gqlResponse = JObject.Parse(await response.Content.ReadAsStringAsync())["data"];

			return gqlResponse;
		}
	}
}