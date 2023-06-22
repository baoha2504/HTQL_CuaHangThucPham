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
                var list = new List<Cart_item>();
                for (int i = 0; i < carts.Count; i++)
                {
                    Cart_item cartitem = new Cart_item();
                    cartitem.product = carts[i].Product;
                    cartitem.Quantity = (int)carts[i].Quantity;
                    cartitem.ProductID = (int)carts[i].ProductID;
                    cartitem.Price = (int)carts[i].Product.PriceNew;
                    list.Add(cartitem);
                }
                Session["SessionCart"] = (List<Cart_item>)list;
                foreach (var cart in carts)
                {
                    sum += ((int)cart.Product.PriceNew * (int)cart.Quantity);
                }
                ViewBag.sum = sum;
                ViewBag.Products = products;
                ViewBag.Blogs = blogs;
            }
            return View();
        }

        public ActionResult About()
        {
            using (var ctx = new GroceryStoreDbContext())
            {
                var blogs = ctx.Blogs.SqlQuery("select * from Blog").ToList();
                ViewBag.Blogs = blogs;
                return View();
            }
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}