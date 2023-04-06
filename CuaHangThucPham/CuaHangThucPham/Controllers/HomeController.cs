using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class HomeController : Controller
    {
        string query = "";
        public ActionResult Index()
        {
            using (var ctx = new GroceryStoreDbContext())
            {
                int sum = 0;
                var products = ctx.Products.SqlQuery("select * from Product").ToList();
                var blogs = ctx.Blogs.SqlQuery("select * from Blog").ToList();
                query = "select * from Cart where CustomerID = N'" + Session["id"] + "'";
                var carts = ctx.Carts.SqlQuery(query).ToList();
                ViewBag.Carts = carts;
                foreach (var cart in carts)
                {
                    sum += (int)cart.Product.PriceNew;
                }
                ViewBag.sum = sum;
                ViewBag.Products = products;
                ViewBag.Blogs = blogs;
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}