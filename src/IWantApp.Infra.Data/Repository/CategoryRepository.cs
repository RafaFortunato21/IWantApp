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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> RemoveAsync(Category category)
        {
             _context.Remove(category.Id);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }

        
        public async Task<Category> GetByIdAsync(Guid categoryId)
        {
            return await _context.Category.AsNoTracking()
                        .Where(cat => cat.Id == categoryId).FirstOrDefaultAsync();
        }

        
    }
}
