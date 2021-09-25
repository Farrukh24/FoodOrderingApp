using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Entities;
using OnlineFoodOrderingSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> GetAllCAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}
