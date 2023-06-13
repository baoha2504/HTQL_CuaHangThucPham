using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsSubcategories = _context.SubCategories.ToList();
            return Ok(dsSubcategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetBillByBillStatus(int id)
        {
            var subCategories = _context.SubCategories.SingleOrDefault(m => m.SubCategoriesId == id);
            return Ok(subCategories);
        }
    }
}
