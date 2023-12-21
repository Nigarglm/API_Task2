﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task<ICollection<CategoryItemDTO>> GetAll(int page, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryItemDTO>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();

            ICollection<CategoryItemDTO> categoryDtos = _mapper.Map<ICollection<CategoryItemDTO>>(categories);

            return categoryDtos;
        }

        public async Task CreateAsync(CategoryCreateDTO categoryDto)
        {
            await _repository.AddAsync(_mapper.Map<Category>(categoryDto));
            await _repository.SaveChangesAsync();
        }

        //public async Task<GetCategoryDto> GetAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);

        //    if (category == null)
        //    {
        //        throw new Exception("Not found");
        //    }

        //    return new GetCategoryDto
        //    {
        //        Id = category.Id,
        //        Name = category.Name
        //    };
        //}



    }
}