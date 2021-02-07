using AutoMapper;

namespace Kitchn.API.GraphQL.Mappings
{
	public class ModelToResourceProfile : Profile
	{
		public ModelToResourceProfile()
		{
			CreateMap<Data.Models.Battery, Services.Models.Battery>();
			CreateMap<Data.Models.Chore, Services.Models.Chore>();
			CreateMap<Data.Models.Location, Services.Models.Location>();
			CreateMap<Data.Models.MeasurementConversion, Services.Models.MeasurementConversion>();
			CreateMap<Data.Models.Measurement, Services.Models.Measurement>();
			CreateMap<Data.Models.ProductBarcode, Services.Models.ProductBarcode>();
			CreateMap<Data.Models.Product, Services.Models.Product>();
			CreateMap<Data.Models.RecipeCategory, Services.Models.RecipeCategory>();
			CreateMap<Data.Models.RecipeInstruction, Services.Models.RecipeInstruction>();
			CreateMap<Data.Models.Recipe, Services.Models.Recipe>();
			CreateMap<Data.Models.StockedItem, Services.Models.StockedItem>();
		}
	}
}