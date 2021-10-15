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
    public class FoodPlaceRepository: RepositoryBase<FoodPlace>, IFoodPlaceRepository
    {
        public FoodPlaceRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<FoodPlace>> Search(string data) =>
                await FindByCondition(x => x.Name.Contains(data) || x.Products.Any(a => a.Name.Contains(data))).ToListAsync();
        
    }
}
