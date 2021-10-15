using Contracts;
using Entities.Data;
using Entities.Models.Entities;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepositoryManager _repo;

        public AdminController(IRepositoryManager repo, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View("Dashboard");
        }

        // GET: Products
        [HttpGet]
        public async Task<ActionResult> Products()
        {
            try
            {
                var products = await _repo.Product.FindAll().ToListAsync();
                if (products is null)
                {
                    return BadRequest("Problem found while getting products! Null cannot be a value!");
                }

                return View(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }

        // GET: Inserting product page
        [HttpGet]        
        public ActionResult InsertProduct()
        {
            return View();
        }

        // POST: Insert product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsertProduct(Product product)
        {
            try
            {
                if(product is null)
                {
                    return NoContent();
                }

                _repo.Product.Create(product);
                await _repo.SaveAsync();

                return RedirectToAction("Products");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }

        // GET: Update Product
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("ID cannot be null!");
                }
                var product = await _repo.Product.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
                if (product is null)
                {
                    return BadRequest("Problem is found while attempting to get data from DB");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }

        // POST: Update Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product is null)
                    {
                        return NotFound();
                    }

                    _repo.Product.Update(product);
                    await _repo.SaveAsync();

                    return RedirectToAction("Products");
                }

                return View(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }                

        // Delete Product                
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {                
                var deleteItem = await _repo.Product.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

                if (deleteItem == null)
                {
                    return NotFound();
                }

                _repo.Product.Delete(deleteItem);
                await _repo.SaveAsync();

                return RedirectToAction("Products");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }


        // FoodPlace
        [HttpGet]
        public async Task<IActionResult> FoodPlaces()
        {
            try
            {
                var foodPlaces = await _repo.FoodPlace.FindAll().ToListAsync();
                if (foodPlaces is null)
                {
                    return BadRequest("Problem found while getting Food Places! Null cannot be a value!");
                }

                return View(foodPlaces);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }

        [HttpGet]
        public ActionResult InsertFoodPlace()
        {
            return View();
        }

        // POST: Insert product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsertFoodPlace(FoodPlace foodPlace)
        {
            try
            {
                if (foodPlace is null)
                {
                    return NoContent();
                }

                _repo.FoodPlace.Create(foodPlace);
                await _repo.SaveAsync();

                return RedirectToAction("FoodPlaces");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }

        // Delete Food Place
        public async Task<ActionResult> DeleteFoodPlace(int? id)
        {
            try
            {
                var deleteItem = await _repo.FoodPlace.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

                if (deleteItem == null)
                {
                    return NotFound();
                }

                _repo.FoodPlace.Delete(deleteItem);
                await _repo.SaveAsync();

                return RedirectToAction("FoodPlaces");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }
        }

        // Users
        public async Task<IActionResult> Users()
        {
            try
            {
                var users = await userManager.Users.ToListAsync();
                var userRolesViewModel = new List<UserViewModel>();
                foreach (User user in users)
                {
                    var thisViewModel = new UserViewModel();
                    thisViewModel.UserId = user.Id;
                    thisViewModel.Email = user.Email;
                    thisViewModel.FirstName = user.FirstName;
                    thisViewModel.LastName = user.LastName;
                    thisViewModel.Roles = await GetUserRoles(user);
                    userRolesViewModel.Add(thisViewModel);
                }
                return View(userRolesViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }            
        }
        // Private helper method for USer
        private async Task<List<string>> GetUserRoles(User user)
        {
            return new List<string>(await userManager.GetRolesAsync(user));
        }

        // User/Manage
        public async Task<IActionResult> Manage(string userId)
        {
            try
            {
                ViewBag.userId = userId;
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                    return View("NotFound");
                }
                ViewBag.UserName = user.UserName;
                var model = new List<ManageUserRoleViewModel>();
                foreach (var role in roleManager.Roles)
                {
                    var userRolesViewModel = new ManageUserRoleViewModel
                    {
                        RoleId = role.Id,
                        RoleName = role.Name
                    };
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRolesViewModel.Selected = true;
                    }
                    else
                    {
                        userRolesViewModel.Selected = false;
                    }
                    model.Add(userRolesViewModel);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }            
        }
        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRoleViewModel> model, string userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return View();
                }
                var roles = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRolesAsync(user, roles);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing roles");
                    return View(model);
                }
                result = await userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected roles to user");
                    return View(model);
                }
                return RedirectToAction("Users");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is: {ex}");
            }            
        }

        // OrderList
        public async Task<IActionResult> OrderList() =>      
            View(await _repo.Order.FindAll().ToListAsync());
     

        // OrderList/Details
        public async Task<IActionResult> OrderDetails([FromRoute] int id) =>
            View(await _repo.Order.FindByCondition(x => x.Id == id).FirstOrDefaultAsync());
        
    }
}
