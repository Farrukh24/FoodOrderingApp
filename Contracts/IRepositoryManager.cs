using Contracts.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        IFoodPlaceRepository FoodPlace { get; }
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderedItemsRepository OrderedItems { get; }
        Task SaveAsync();
    }
}
