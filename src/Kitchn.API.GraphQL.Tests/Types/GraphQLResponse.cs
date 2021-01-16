using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kitchn.API.GraphQL.Tests.Types
{
	public class GraphQLResponse
	{
		[JsonProperty("data")]
		public JToken Data { get; set; }

		[JsonProperty("errors")]
		public JToken Errors { get; set; }
	}
}
