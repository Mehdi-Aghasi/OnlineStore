using AutoMapper;
using OnlineStore.Application.Common.DTOs.Carts;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Common.Mappings
{
    public class CartProfile:Profile
    {
        public CartProfile()
        {
            CreateMap<Cart,CartDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));
            CreateMap<CartItem,CartItemDto>()
                .ForMember(dest=>dest.ProductName,opt=>opt.MapFrom(src=>src.Product.Name));
        }
    }
}
