using CuaHangThucPham.Models;
using System.Linq;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();

        public ActionResult Index()
        {
            var blogs = ctx.Blogs.SqlQuery("select * from Blog").ToList();
            ViewBag.Blogs = blogs;
            return View();
        }
        public ActionResult SingaleBlog(int id)
        {
            string query = "select * from Blog where BlogID = " + id;
            var blogs = ctx.Blogs.SqlQuery(query).ToList();
            ViewBag.Blogs = blogs;

            return View();
        }
    }
}