using Contracts;
using Entities.Models.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Helpers;
using OnlineFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "CartSessionKey";
        private readonly IProductRepository _product;
        public CartController(IProductRepository product)
        {
            _product = product;
        }


        public async Task<IActionResult> Index()
        {
            var cart = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();
            var products = await _product.GetAllAsync();
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

            return View(selectedItems);
        }

        [HttpPost]
        public ActionResult AddToCart([FromRoute] int id)
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

        public IActionResult Remove([FromRoute] int id)
        {
            List<ShoppingItem> shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>(CartSessionKey) ?? new List<ShoppingItem>();

            var foundItem = shoppingItems.Find(i => i.ProductId == id);
            shoppingItems.Remove(foundItem);
            HttpContext.Session.Set(CartSessionKey, shoppingItems);

            return RedirectToAction("Index");
        }

        public IActionResult Plus([FromRoute] int id)
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

        public IActionResult Minus([FromRoute] int id)
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
    }
}
