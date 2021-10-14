using Contracts;
using Entities.Data;
using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext): base(dbContext)
        {
        }
    }
}
