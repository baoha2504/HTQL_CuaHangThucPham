using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BlogController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet]
        public IActionResult GetAllBlog()
        {
            var blogs = _context.Blogs.ToList();
            return Ok(blogs);
        }
    }
}
