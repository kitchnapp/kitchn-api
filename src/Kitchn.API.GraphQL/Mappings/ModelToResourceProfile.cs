using AutoMapper;

namespace Kitchn.API.GraphQL.Mappings
{
	public class ModelToResourceProfile : Profile
	{
		public ModelToResourceProfile()
		{
			CreateMap<Data.Models.Chore, GraphQL.Models.Chores.Chore>();
			CreateMap<Data.Models.Location, GraphQL.Models.Locations.Location>();
		}
	}
}