using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet]
        public IActionResult GetAllBill()
        {
            var bills = _context.Bills.ToList();
            return Ok(bills);
        }
    }
}
