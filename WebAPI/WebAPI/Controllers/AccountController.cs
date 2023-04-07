using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly GroceryStoreContext _context;

        public AccountController(GroceryStoreContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("{emailCustomer}")]
        public IActionResult CheckCustomer(string email, string pass)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Email == email);
            if (customer != null)
            {
                if (customer.PassWord == pass && customer.Access == 3 && customer.Prohibit == 1) {
                    return Ok(customer);
                } 
                else {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{emailAdmin}")]
        public IActionResult CheckAdmin(string email, string pass)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Email == email);
            if (customer != null)
            {
                if (customer.PassWord == pass && (customer.Access == 1 || customer.Access == 2) && customer.Prohibit == 1)
                {
                    return Ok(customer);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ChangePass(string email, string pass, string newpass)
        {

            var customer = _context.Customers.SingleOrDefault(m => m.Email == email);
            if (customer != null)
            {
                if (customer.PassWord == pass && customer.Prohibit == 1)
                {
                    customer.PassWord = newpass;
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
