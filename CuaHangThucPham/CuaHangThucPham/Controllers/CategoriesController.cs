using CuaHangThucPham.Models;
using System.Linq;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        string query = "";
        public ActionResult Index(int? CategoriesID)
        {
            try
            {
                query = "select * from Product, SubCategories where Product.SubCategoriesID = SubCategories.SubCategoriesID and SubCategories.CategoriesID = " + CategoriesID;
                var products = ctx.Products.SqlQuery(query).ToList();
                ViewBag.Products = products;
                return View();
            }
            catch
            {
                query = "select * from Product";
                var products = ctx.Products.SqlQuery(query).ToList();
                ViewBag.Products = products;
                return View();
            }
        }
    }
}