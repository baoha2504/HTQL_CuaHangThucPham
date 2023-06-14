using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shipping = _context.Payments.SingleOrDefault(m => m.PaymentId == id);
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
