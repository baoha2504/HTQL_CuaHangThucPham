using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
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
            if (blogs != null)
            {
                return Ok(blogs);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAllBlogById(int id)
        {
            var blog = _context.Blogs.SingleOrDefault(m => m.BlogId == id);
            if (blog != null)
            {
                return Ok(blog);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            try
            {
                var bl = new Blog
                {
                    BlogId = blog.BlogId,
                    DateAdded = blog.DateAdded,
                    Title = blog.Title,
                    Content = blog.Content,
                    Image = blog.Image,
                    CustomerId = blog.CustomerId,
                };
                _context.Add(bl);
                _context.SaveChanges();
                return Ok(bl);
            }
            catch
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogById(int id, Blog blog)
        {
            var dsBlog = _context.Blogs.SingleOrDefault(m => m.BlogId == id);
            if (dsBlog != null)
            {
                dsBlog.DateAdded = blog.DateAdded;
                dsBlog.Title = blog.Title;
                dsBlog.Content = blog.Content;
                dsBlog.Image = blog.Image;
                dsBlog.CustomerId = blog.CustomerId;

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
