using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepositoryManager _repo;
        public OrderController(IRepositoryManager repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Number([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return NoContent();
                }
                var item = await _repo.OrderedItems.FindByCondition(x => x.OrderDetailId == id).ToListAsync();

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyOrders([FromRoute] string id)
        {
            try
            {
                if (id is null)
                {
                    return BadRequest("Id is Null!");
                }
                var orders = await _repo.Order.FindByCondition(x => x.UserId == id).ToListAsync();

                return View(orders);
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Id cannot be equal to 0! ");
                }

                return View(await _repo.OrderDetail.FindByCondition(x => x.OrderId == id).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new Exception($"Problem is found: {ex}");
            }            
        }
    }
}
