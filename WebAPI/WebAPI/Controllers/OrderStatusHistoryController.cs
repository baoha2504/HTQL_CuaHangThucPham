using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusHistoryController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpPost]
        public IActionResult CreateOrderStatusHistory(OrderStatusHistory orderStatusHistory)
        {
            try
            {
                var odsh = new OrderStatusHistory
                {
                   OrderStatusName = orderStatusHistory.OrderStatusName,
                   DateAdd = orderStatusHistory.DateAdd,
                   OrderId = orderStatusHistory.OrderId,
                   CanceledBy = orderStatusHistory.CanceledBy,
                };
                _context.Add(odsh);
                _context.SaveChanges();
                return Ok(odsh);
            }
            catch
            {
                return BadRequest(0);
            }
        }
    }
}
