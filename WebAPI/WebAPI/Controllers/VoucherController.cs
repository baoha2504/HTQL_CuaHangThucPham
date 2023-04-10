using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet]
        public IActionResult GetAllInventory()
        {
            var vouchers = _context.Vouchers.ToList();
            return Ok(vouchers);
        }
    }
}
