﻿using OnlineFoodOrderingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Repositories.Interfaces
{
    public interface IFoodPlaceRepository
    {
        Task<IEnumerable<FoodPlace>> GetAllAsync();
        Task<FoodPlace> GetPlaceByIdAsync(int id);
        Task<FoodPlace> CreatePlaceAsync(FoodPlace foodPlace);
        Task UpdatePlaceAsync(FoodPlace foodPlace);
        Task DeletePlaceAsync(int id);
    }
}