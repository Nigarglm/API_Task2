using AutoMapper;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryItemDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, IncludeCategoryDTO>().ReverseMap();
        }
    }
}
