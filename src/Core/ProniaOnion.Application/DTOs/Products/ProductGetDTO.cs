using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.DTOs.Products
{
    public record ProductGetDTO(int Id, string Name, decimal Price, string SKU, string? Description,int CategoryId,IncludeCategoryDTO Category);
}
