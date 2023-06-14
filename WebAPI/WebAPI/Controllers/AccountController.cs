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
        [HttpGet("{id}")]
        public IActionResult GetAllCustomerByID(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.CustomerId == id);
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
        public IActionResult GetAllCustomerEmail(string email, string pass)
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

        [HttpPut("{id}")]
        public IActionResult UpdateAccountById(int id, Customer customer)
        {
            var cus = _context.Customers.SingleOrDefault(m => m.CustomerId == id);
            if (cus != null)
            {
                cus.FirstName = customer.FirstName;
                cus.LastName = customer.LastName;
                cus.Email = customer.Email;
                cus.PassWord = customer.PassWord;
                cus.Phone = customer.Phone;
                cus.Company = customer.Company;
                cus.Address1 = customer.Address1;
                cus.Address2 = customer.Address2;
                cus.City = customer.City;
                cus.Access = customer.Access;
                cus.Prohibit = customer.Prohibit;

                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
