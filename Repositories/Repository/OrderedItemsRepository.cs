using Contracts.IRepository;
using Entities.Data;
using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class OrderedItemsRepository: RepositoryBase<OrderedItems>, IOrderedItemsRepository
    {
        public OrderedItemsRepository(AppDbContext dbContext): base(dbContext)
        {
        }
    }
}
