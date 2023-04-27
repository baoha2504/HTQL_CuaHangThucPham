using CuaHangThucPham.Models;
using System.Linq;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

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
        public ActionResult SearchProduct(string name, string price)
        {
            if (name != string.Empty && price != string.Empty)
            {
                price = price.Replace("₫", "");
                price = price.Replace(".", "");

                // Tách chuỗi thành 2 phần
                string[] parts = price.Split('-');

                query = "select * from Product where ProductName LIKE N'%" + name + "%' " +
                    "and (PriceNew BETWEEN " + parts[0].Trim() + " AND " + parts[1].Trim() + ")";
                var products = ctx.Products.SqlQuery(query).ToList();
                ViewBag.Products = products;
                return View();
            } else if (name == string.Empty && price != string.Empty)
            {
                price = price.Replace("₫", "");
                price = price.Replace(".", "");

                // Tách chuỗi thành 2 phần
                string[] parts = price.Split('-');

                query = "select * from Product where (PriceNew BETWEEN " + parts[0].Trim() + " AND " + parts[1].Trim() + ")";
                var products = ctx.Products.SqlQuery(query).ToList();
                ViewBag.Products = products;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}