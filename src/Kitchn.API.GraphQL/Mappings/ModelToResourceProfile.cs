using AutoMapper;

namespace Kitchn.API.GraphQL.Mappings
{
	public class ModelToResourceProfile : Profile
	{
		public ModelToResourceProfile()
		{
			CreateMap<Data.Models.Chore, GraphQL.Models.Chores.Chore>();
			CreateMap<Data.Models.Location, GraphQL.Models.Locations.Location>();
			CreateMap<Data.Models.Recipe, GraphQL.Models.Recipes.Recipe>();
			CreateMap<Data.Models.Measurement, GraphQL.Models.Measurements.Measurement>();
		}
	}
}