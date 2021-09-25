using OnlineFoodOrderingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCAsync();
        Task<Category> GetCategoryByIdAsync(int id);
    }
}
