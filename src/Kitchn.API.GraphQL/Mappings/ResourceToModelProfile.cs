using AutoMapper;

namespace Kitchn.API.GraphQL.Mappings
{
	public class ResourceToModelProfile : Profile
	{
		public ResourceToModelProfile()
		{
			CreateMap<GraphQL.Models.Chores.Chore, Data.Models.Chore>();
		}
	}
}