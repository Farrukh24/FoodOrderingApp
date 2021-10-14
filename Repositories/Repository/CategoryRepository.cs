using Contracts;
using Entities.Data;
using Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {      
        public CategoryRepository(AppDbContext dbContext): base(dbContext)
        {
           
        }
       
    }
}
