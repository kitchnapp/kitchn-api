using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kitchn.API.GraphQL.Tests.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kitchn.API.GraphQL.Tests.Types
{
	public class GraphQLRequest
	{
		[JsonProperty("query")]
		public string Query { get; set; }

		[JsonProperty("variables")]
		public object Variables { get; set; }

		private StringContent GetRequest()
		{
			var jsonQuery = JsonConvert.SerializeObject(this);
			var stringContent = new StringContent(jsonQuery, Encoding.UTF8, "application/json");

			return stringContent;
		}

		public async Task<GraphQLResponse> Send(HttpClient client)
		{
			var response = await client.PostAsync("/graphql", GetRequest());

			var gqlResponse = JsonConvert.DeserializeObject<GraphQLResponse>(await response.Content.ReadAsStringAsync());

			return gqlResponse;
		}
	}
}