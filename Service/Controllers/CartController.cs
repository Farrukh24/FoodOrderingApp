using Contracts;
using Entities.Data;
using Entities.Models.Cart;
using Entities.Models.Entities;
using Entities.Models.Enum;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineFoodOrderingSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly string CartSessionKey;
        private readonly IRepositoryManager _repo;
        private readonly UserManager<User> _userManager;
        public CartController(IRepositoryManager repo, IConfiguration configuration, UserManager<User> userManager)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            CartSessionKey = configuration.GetSection("Cart").GetSection("Key").Value;
        }

        // Get products which are in the Cart
        public async Task<IActionResult> Index() => View(await CartItems());  
        

        // Add products to the Cart
        [HttpPost]
        public ActionResult AddToCart([FromRoute] int id)
        {
            try
            {
                var shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();

                if (!shoppingItems.Any())
                {
                    shoppingItems.Add(new ShoppingItem { ProductId = id, Quantity = 1 });
                }
                else
                {
                    var foundItem = shoppingItems.Find(i => i.ProductId == id);
                    if (foundItem is null)
                    {
                        shoppingItems.Add(new ShoppingItem { ProductId = id, Quantity = 1 });
                    }
                    else
                    {
                        foundItem.Quantity++;
                    }
                }
                HttpContext.Session.Set(CartSessionKey, shoppingItems);

                return RedirectToAction("Products", "Cart", new { id = 1 });
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }


        // Remove products from the Cart
        public IActionResult Remove([FromRoute] int id)
        {
            try
            {
                List<ShoppingItem> shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();

                var foundItem = shoppingItems.Find(i => i.ProductId == id);
                
                shoppingItems.Remove(foundItem);
                HttpContext.Session.Set(CartSessionKey, shoppingItems);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }


        // Increase quantity of products in the Cart
        public IActionResult Plus([FromRoute] int id)
        {
            try
            {
                List<ShoppingItem> shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();

                var foundItem = shoppingItems.Find(i => i.ProductId == id);

                if (foundItem != null)
                {
                    foundItem.Quantity++;
                }

                HttpContext.Session.Set(CartSessionKey, shoppingItems);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }

        }


        // Decrease quantity of products in the Cart 
        public IActionResult Minus([FromRoute] int id)
        {
            try
            {
                List<ShoppingItem> shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();

                var foundItem = shoppingItems.Find(i => i.ProductId == id);

                if (foundItem != null)
                {
                    foundItem.Quantity--;
                }
                if (foundItem.Quantity == 0)
                {
                    shoppingItems.Remove(foundItem);
                }

                HttpContext.Session.Set(CartSessionKey, shoppingItems);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }
        }

        // Checkout        
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var model = new CheckoutViewModel();

                model.CartItems = await CartItems();
                model.User = await _userManager.GetUserAsync(HttpContext.User);

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }
        
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutVM)
        {
            try
            {
                checkoutVM.CartItems = await CartItems();

                var user = await _userManager.GetUserAsync(HttpContext.User);

                var order = new Order
                {
                    UserId = _userManager.GetUserId(HttpContext.User),
                    DeliverType = checkoutVM.DeliverType,
                    PaymentType = checkoutVM.PaymentType,
                    Adress = checkoutVM.User.Address,
                    PhoneNumber = checkoutVM.User.PhoneNumber,
                    Email = user.Email,
                    FirstName = checkoutVM.User.FirstName,
                    LastName = checkoutVM.User.LastName,
                    Total = checkoutVM.CartItems.Sum(x => x.Quantity * x.Price),
                    CreatedOn = DateTime.Now,
                    Status = Status.Received
                };
                _repo.Order.Create(order);
                await _repo.SaveAsync();

                var orderList = new List<OrderedItems>();
                foreach (var item in checkoutVM.CartItems)
                {
                    orderList.Add(new OrderedItems()
                    {
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    Quantity = checkoutVM.CartItems.Sum(q => q.Quantity),
                    Price = order.Total,
                    OrderedItems = orderList
                };

                _repo.OrderDetail.Create(orderDetail);
                await _repo.SaveAsync();

                HttpContext.Session.Remove(CartSessionKey);

                return RedirectToAction("Number", "Order", new { id = orderDetail.Id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }           

        }


        // Private helper method in order to decreade to write same codes
        private async Task<IEnumerable<ProductCart>> CartItems()
        {
            try
            {
                var cart = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();
                
                var products = await _repo.Product.FindAll().ToListAsync();
                
                var selectedItems = cart.Join(products, i => i.ProductId, o => o.Id, (cartItem, product) =>
                    new ProductCart()
                    {
                        Quantity = cartItem.Quantity,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Total = cartItem.Quantity * product.Price,
                        Id = cartItem.ProductId

                    }
                );

                return selectedItems;
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }
    }
}
