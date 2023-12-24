using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductItemDTO>().ReverseMap();
            CreateMap<Product, ProductGetDTO>().ReverseMap();
            CreateMap<ProductCreateDTO, Product>();
        }
    }
}
