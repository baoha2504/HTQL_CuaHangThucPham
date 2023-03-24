using CuaHangThucPham.Models;
using System.Linq;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class ProductController : Controller
    {
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        string query = "";
        public ActionResult Index()
        {
            query = "select * from Product";
            var products = ctx.Products.SqlQuery(query).ToList();
            ViewBag.Products = products;
            return View();
        }
        public ActionResult DetailProduct(int ID)
        {
            query = "select * from Product where ProductID = " + ID;
            var product = ctx.Products.SqlQuery(query).ToList();
            ViewBag.Product = product;

            query = "select Top(6) * from Product";
            var products = ctx.Products.SqlQuery(query).ToList();
            ViewBag.Products = products;
            return View();
        }
    }
}