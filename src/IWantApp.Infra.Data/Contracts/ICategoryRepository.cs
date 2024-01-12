using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Infra.Data.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
        Task<Category> GetByIdAsync(Guid categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();

    }
}
