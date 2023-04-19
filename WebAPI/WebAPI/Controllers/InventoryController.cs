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

        [HttpPost]
        public IActionResult CreateInventory([FromBody] Inventory inventory)
        {
            try
            {
                var i = new Inventory
                {
                    Quantity = inventory.Quantity,
                    InventoryNumber = inventory.InventoryNumber,
                    DateAdded = inventory.DateAdded,
                    ExpirationDate = inventory.ExpirationDate,
                    CustomerId = inventory.CustomerId,
                    ProductId = inventory.ProductId,
                };
                _context.Add(i);
                _context.SaveChanges();
                return Ok(i);
            }
            catch
            {
                return BadRequest(0);
            }
        }
    }
}
