using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Model;

namespace NLayerService.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<ProductUpdateDTO,Product>().ReverseMap();
            CreateMap<Product, ProductWithCatagoryDto>();
            CreateMap<Category, CategoryWithProductDto>();
        }
    }
}
