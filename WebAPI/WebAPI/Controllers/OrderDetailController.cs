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
    }
}
