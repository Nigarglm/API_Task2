using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDTO>> GetAllPaginated(int page, int take);
        Task<ProductGetDTO> GetByIdAsync(int id);
        Task CreateAsync(ProductCreateDTO dto);
        Task UpdateAsync(int id, ProductUpdateDTO dto);
    }
}
