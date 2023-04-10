using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet]
        public IActionResult GetAllInventory()
        {
            var inventory = _context.Inventories.ToList();
            return Ok(inventory);
        }

        [HttpGet("{InventoryID}")]
        public IActionResult GetByInventoryID(int InventoryID)
        {
            var inventory = _context.Inventories.SingleOrDefault(m => m.InventoryID == InventoryID);
            if (inventory != null)
            {
                return Ok(inventory);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
