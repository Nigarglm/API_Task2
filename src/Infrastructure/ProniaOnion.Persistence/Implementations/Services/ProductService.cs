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
using ProniaOnion.Domain.Entities;

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

        public async Task<ProductGetDTO> GetByIdAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id,includes:nameof(Product.Category));
            ProductGetDTO dto = _mapper.Map<ProductGetDTO>(product);
            return dto;
        }
    }
}
