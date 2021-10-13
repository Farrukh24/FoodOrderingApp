using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IFoodPlaceRepository _repo;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        public CategoryController(IFoodPlaceRepository repo, IProductRepository product, ICategoryRepository category)
        {
            _repo = repo;
            _product = product;
            _category = category;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            var selectedCategory = await _category.GetCategoryByIdAsync(id);

            var foodPlaces = await _repo.GetAllAsync();

            if (foodPlaces is null)
            {
                return BadRequest("Problem is found while getting data from DB! Returning data is NULL.");
            }

            return View(foodPlaces.Where(i => i.CategoryId == id));

        }

        [HttpGet]
        public async Task<ActionResult> Products([FromRoute] int id)
        {
            var products = await _product.GetProductsByPlaceId(id);
            if (products is null)
            {
                return BadRequest("Problem is found while getting Products from DB! Returning data is NULL.");
            }

            return View(products);
        }
    }
}
