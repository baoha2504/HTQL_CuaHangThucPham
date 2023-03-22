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
        public ActionResult Index()
        {
            using (var ctx = new GroceryStoreDbContext())
            {
                var products = ctx.Products.SqlQuery("select * from Product").ToList();
                var blogs = ctx.Blogs.SqlQuery("select * from Blog").ToList();
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