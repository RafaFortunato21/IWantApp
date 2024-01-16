using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(Guid categoryId);

        Task Add(CategoryResponse categoryDTO, string userCreate);
        Task Update(CategoryUpdateDTO category, Guid categoryId, string userUpdate);
        
    }
}
