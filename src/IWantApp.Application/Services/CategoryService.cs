using AutoMapper;
using IWantApp.Application.Contracts;
using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using IWantApp.Infra.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository  = categoryRepository;
            _mapper = mapper;
        }
        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);


            await _categoryRepository.CreateAsync(category);

        }

        public async Task Remove(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
                throw new Exception("Category not found");

            await _categoryRepository.RemoveAsync(category);


        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task Update(CategoryUpdateDTO categoryDto, Guid categoryId)
        {
            try
            {
                //Verifica se o usuario Existe
                var categoryEntity = await _categoryRepository.GetByIdAsync(categoryId);

                if (categoryEntity == null)
                    throw new Exception($"Entity could not be loaded.");

                categoryDto.Id = categoryEntity.Id;
                _mapper.Map(categoryDto, categoryEntity);

                //Atualizar o usuario
                await _categoryRepository.UpdateAsync(categoryEntity);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro:"+ex.Message);
            }
        }

        public async Task<CategoryDTO> GetById(Guid categoryId)
        {

            var category = await _categoryRepository.GetByIdAsync(categoryId);

            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
