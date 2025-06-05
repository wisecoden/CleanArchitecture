using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryrepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryrepository, IMapper mapper)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var entities = await _categoryrepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(entities);
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var entity = await _categoryrepository.GetByIdAsync(id);
            return _mapper.Map<CategoryViewModel>(entity);
        }
    }
}
