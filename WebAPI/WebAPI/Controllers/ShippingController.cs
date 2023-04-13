using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shipping = _context.Shippings.SingleOrDefault(m => m.ShippingId == id);
            if (shipping != null)
            {
                return Ok(shipping);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
