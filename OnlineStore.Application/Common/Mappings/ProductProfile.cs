using AutoMapper;
using OnlineStore.Application.Common.DTOs.Products;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Common.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
