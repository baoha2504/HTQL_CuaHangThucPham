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

        [HttpGet]
        public IActionResult GetAll()
        {
            var customer = _context.Customers.ToList();
            if (customer != null)
            {
                    return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{email}&{pass}")]
        public IActionResult GetAllCustomerByID(string email, string pass)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Email == email);
            if (customer != null)
            {
                if (customer.PassWord == pass && customer.Prohibit == 1)
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
