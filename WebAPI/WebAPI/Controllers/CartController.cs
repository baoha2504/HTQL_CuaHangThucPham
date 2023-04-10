using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet("{CustomerId}")]
        public IActionResult GetByInventoryID(int CustomerId)
        {
            var cart = _context.Carts.Where(m => m.CustomerId == CustomerId).ToList();
            if (cart != null)
            {
                return Ok(cart);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
