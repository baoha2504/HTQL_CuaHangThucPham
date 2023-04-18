using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
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

        [HttpPost]
        public IActionResult CreateBill([FromBody] Bill bill)
        {
            try
            {
                var b = new Bill
                {
                    OrderDate = bill.OrderDate,
                    CustomerId = bill.CustomerId,
                    Total = bill.Total,
                };
                _context.Add(b);
                _context.SaveChanges();
                return Ok(b);
            }
            catch
            {
                return BadRequest(0);
            }
        }
    }
}
