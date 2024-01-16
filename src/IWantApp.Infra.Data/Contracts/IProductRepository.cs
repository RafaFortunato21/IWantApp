using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Infra.Data.Contracts
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        //Task<Category> UpdateAsync(Category category);
        //Task<Category> RemoveAsync(Category category);
        Task<Product> GetByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsAsync();

    }
}
