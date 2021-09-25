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
    public class FoodPlaceRepository: IFoodPlaceRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodPlaceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<FoodPlace> CreatePlaceAsync(FoodPlace foodPlace)
        {
            await _db.FoodPlaces.AddAsync(foodPlace);
            await _db.SaveChangesAsync();

            return foodPlace;
        }

        public async Task DeletePlaceAsync(int id)
        {
            var deletePlace = await _db.FoodPlaces.FindAsync(id);
            _db.FoodPlaces.Remove(deletePlace);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodPlace>> GetAllAsync()
        {
            return await _db.FoodPlaces.ToListAsync();
        }

        public async Task<FoodPlace> GetPlaceByIdAsync(int id)
        {
            return await _db.FoodPlaces.FindAsync(id);
        }

        public async Task UpdatePlaceAsync(FoodPlace foodPlace)
        {
            _db.Entry(foodPlace).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
