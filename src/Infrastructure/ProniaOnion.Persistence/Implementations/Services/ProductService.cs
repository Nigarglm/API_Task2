using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository,IColorRepository colorRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _colorRepository = colorRepository;
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

        public async Task CreateAsync([FromForm] ProductCreateDTO dto)
        {
           // if(await _repository.IsExistAsync(p=>p.Name==dto.Name)) throw new Exception("Product with this name is already exists");    ERROOOOORRRRRR
           // if (!await _categoryRepository.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("dont");                      ERROOOOORRRRRR

            Product product = _mapper.Map<Product>(dto);
            product.ProductColors = new List<ProductColor>();
            foreach (var colorId in dto.ColorIds)
            {
               // if (await _colorRepository.IsExistAsync(c => c.Id == colorId)) throw new Exception("dont");      ERROOOOORRRRRR
                product.ProductColors.Add(new ProductColor { ColorId = colorId });
            }

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ProductUpdateDTO dto)
        {
            Product existed= await _repository.GetByIdAsync(id, includes:nameof(Product.ProductColors));
            if (existed == null) throw new Exception("dont");

            if (dto.CategoryId != existed.CategoryId)
               // if (!await _categoryRepository.IsExistAsync(c => c.Id == dto.CategoryId))           ERROOOORRRRRRR
                    throw new Exception("dont");
             
            existed = _mapper.Map(dto, existed);
            existed.ProductColors = existed.ProductColors.Where(pc => dto.ColorIds.Any(colId => pc.ColorId == colId)).ToList();
            //foreach (var colorId in dto.ColorIds.Where(colId => productColors.Any(pc => colId == pc.Id)))
            //{
            //    if (!await _colorRepository.IsExistAsync(c => c.Id == colorId)) throw new Exception("dont");
            //    existed.ProductColors.Add(new ProductColor { ColorId = colorId });
            //}
            foreach (var cId in dto.ColorIds)
            {
                //if (!await _colorRepository.IsExistAsync(c => c.Id == cId)) throw new Exception("exception");           ERROOOORRRRRRR
                if (!existed.ProductColors.Any(pc => pc.ColorId == cId))
                {
                    existed.ProductColors.Add(new ProductColor { ColorId = cId});
                }
            }
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
