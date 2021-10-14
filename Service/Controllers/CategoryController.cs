using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepositoryManager _repo;
        
        // Constructor
        public CategoryController(IRepositoryManager repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            try
            {
                var selectedCategory = await _repo.Category.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

                var foodPlaces = await _repo.FoodPlace.FindAll().ToListAsync();

                if (foodPlaces is null)
                {
                    return BadRequest("Problem is found while getting List of FoodPlaces from DB! Returning data is NULL.");
                }

                return View(foodPlaces.Where(i => i.CategoryId == id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }  
        }

        [HttpGet]
        public async Task<ActionResult> Products([FromRoute] int id)
        {
            try
            {
                var products = await _repo.Product.FindByCondition(x => x.FoodPlaceId == id).ToListAsync();

                if (products is null)
                {
                    return BadRequest("Problem is found while getting Products from DB! Returning data is NULL!");
                }

                return View(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }           
        }
    }
}
