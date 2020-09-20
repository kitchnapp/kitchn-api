using AutoMapper;

namespace Kitchn.API.GraphQL.Mappings
{
	public class ResourceToModelProfile : Profile
	{
		public ResourceToModelProfile()
		{
			CreateMap<GraphQL.Models.Chores.Chore, Data.Models.Chore>();
			CreateMap<GraphQL.Models.Locations.Location, Data.Models.Location>();
			CreateMap<GraphQL.Models.Recipes.Recipe, Data.Models.Recipe>();
			CreateMap<GraphQL.Models.RecipeInstructions.RecipeInstruction, Data.Models.RecipeInstruction>();
			CreateMap<GraphQL.Models.Measurements.Measurement, Data.Models.Measurement>();
			CreateMap<GraphQL.Models.ProductBarcodes.ProductBarcode, Data.Models.ProductBarcode>();
		}
	}
}