using AutoMapper;
using OnlineStore.Application.Common.DTOs.Categories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Common.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryDto>();
        }
    }
}
