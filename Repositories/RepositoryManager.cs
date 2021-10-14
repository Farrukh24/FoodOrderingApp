using Contracts;
using Contracts.IRepository;
using Entities.Data;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext db;
        private ICategoryRepository categoryRepository;
        private IFoodPlaceRepository foodPlaceRepository;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;
        private IOrderedItemsRepository orderedItemsRepository;

        public RepositoryManager(AppDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public ICategoryRepository Category
        {
            get
            {               
                if(categoryRepository is null)
                {
                    categoryRepository = new CategoryRepository(db);
                }
                return categoryRepository;
            }
        }

        public IFoodPlaceRepository FoodPlace
        {
            get
            {
                if (foodPlaceRepository is null)
                {
                    foodPlaceRepository = new FoodPlaceRepository(db);
                }
                return foodPlaceRepository;
            }
        }    

        public IProductRepository Product
        {
            get
            {
                if (productRepository is null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                if(orderRepository is null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }
        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if(orderDetailRepository is null)
                {
                    orderDetailRepository = new OrderDetailRepository(db);
                }
                return orderDetailRepository;
            }
        }
        public IOrderedItemsRepository OrderedItems
        {
            get
            {
                if(orderedItemsRepository is null)
                {
                    orderedItemsRepository = new OrderedItemsRepository(db);
                }
                return orderedItemsRepository;
            }
        }

        public Task SaveAsync() => db.SaveChangesAsync();
        
    }
}
