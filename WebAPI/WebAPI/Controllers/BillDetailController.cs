using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpPost]
        public IActionResult CreateBillDetail(BillDetail billDetail)
        {
            try
            {
                var bd = new BillDetail
                {
                    Quantity = billDetail.Quantity,
                    Price = billDetail.Price,
                    BillId = billDetail.BillId,
                    ProductId = billDetail.ProductId,
                };
                _context.Add(bd);
                _context.SaveChanges();
                return Ok(bd);
            }
            catch
            {
                return BadRequest(0);
            }
        }
    }
}
