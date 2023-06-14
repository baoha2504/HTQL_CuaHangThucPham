using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpPost]
        public IActionResult CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var oddt = new OrderDetail
                {
                    OrderId = orderDetail.OrderId,
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.OrderId,
                    Price = orderDetail.Price,
                };
                _context.Add(oddt);
                _context.SaveChanges();
                return Ok(oddt);
            }
            catch
            {
                return BadRequest(0);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailByID(int id)
        {
            var oddt = _context.OrderDetails.Where(m => m.OrderId == id).ToList();
            if (oddt != null)
            {
                return Ok(oddt);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
