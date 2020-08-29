using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Kitchn.API.GraphQL.Models
{
	public class KitchnSchema : Schema
	{
		public KitchnSchema(IServiceProvider provider) : base(provider)
		{
			Query = provider.GetRequiredService<KitchnQuery>();
		}
	}
}