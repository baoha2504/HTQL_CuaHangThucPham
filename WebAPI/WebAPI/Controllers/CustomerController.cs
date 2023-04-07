using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly GroceryStoreContext _context;

        public CustomerController(GroceryStoreContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            try
            {
                var cus = new Customer
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address1 = customer.Address1,
                    Access = customer.Access,
                    Phone = customer.Phone,
                    Prohibit = customer.Prohibit

                };
                _context.Add(cus);
                _context.SaveChanges();
                return Ok(cus);
            }
            catch
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomerById(int id, Customer cus)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.CustomerId == id);
            if (customer != null)
            {

                customer.CustomerId = cus.CustomerId;
                customer.FirstName = cus.FirstName;
                customer.LastName = cus.LastName;
                customer.Address1 = cus.Address1;
                customer.Access = cus.Access;
                customer.Phone = cus.Phone;
                customer.Prohibit = cus.Prohibit;
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
