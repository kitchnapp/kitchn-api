using AutoMapper;

namespace Kitchn.API.GraphQL.Mappings
{
	public class ResourceToModelProfile : Profile
	{
		public ResourceToModelProfile()
		{
			CreateMap<Services.Models.Battery, Data.Models.Battery>();
			CreateMap<Services.Models.Chore, Data.Models.Chore>();
			CreateMap<Services.Models.Location, Data.Models.Location>();
			CreateMap<Services.Models.MeasurementConversion, Data.Models.MeasurementConversion>();
			CreateMap<Services.Models.Measurement, Data.Models.Measurement>();
			CreateMap<Services.Models.ProductBarcode, Data.Models.ProductBarcode>();
			CreateMap<Services.Models.Product, Data.Models.Product>();
			CreateMap<Services.Models.RecipeCategory, Data.Models.RecipeCategory>();
			CreateMap<Services.Models.RecipeInstruction, Data.Models.RecipeInstruction>();
			CreateMap<Services.Models.Recipe, Data.Models.Recipe>();
			CreateMap<Services.Models.StockedItem, Data.Models.StockedItem>();
		}
	}
}