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
			CreateMap<Data.Models.RecipeInstruction, GraphQL.Models.RecipeInstructions.RecipeInstruction>();
			CreateMap<Data.Models.RecipeCategory, GraphQL.Models.RecipeCategories.RecipeCategory>();
			CreateMap<Data.Models.Measurement, GraphQL.Models.Measurements.Measurement>();
			CreateMap<Data.Models.MeasurementConversion, GraphQL.Models.MeasurementConversions.MeasurementConversion>();
			CreateMap<Data.Models.ProductBarcode, GraphQL.Models.ProductBarcodes.ProductBarcode>();
			CreateMap<Data.Models.StockedItem, GraphQL.Models.StockedItems.StockedItem>();
		}
	}
}