using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductItemDTO>> GetAllPaginated(int page, int take)
        {
            IEnumerable<ProductItemDTO> dtos = _mapper.Map<IEnumerable<ProductItemDTO>>(await _repository.GetAllWhere(skip: (page-1)*take, take: take, isTracking:false).ToArrayAsync());
            return dtos;
        }
    }
}
