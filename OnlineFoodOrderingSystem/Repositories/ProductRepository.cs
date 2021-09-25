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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProduct = await _db.Products.FindAsync(id);
            _db.Products.Remove(deleteProduct);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByPlaceId(int id)
        {
            var searchProducts = await _db.Products.FindAsync(id);

            return await _db.Products.Where(i => i.FoodPlaceId == id).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
