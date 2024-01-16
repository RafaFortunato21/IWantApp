using IWantApp.Domain.Entities;
using IWantApp.Infra.Data.Context;
using IWantApp.Infra.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IWantApp.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            var query = _context.Product
                            .Include(p => p.Category)
                           .Where(prod => prod.Id == productId).AsNoTracking();

            return  await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Product
                        .Include(p => p.Category)    
                        .ToListAsync(); 
        }
    }
}
