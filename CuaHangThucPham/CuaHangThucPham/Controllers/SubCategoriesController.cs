using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class SubCategoriesController : Controller
    {
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        string query = "";
        // GET: SubCategories
        public ActionResult Index(int SubCategoriesID)
        {
            try
            {
                query = "select * from Product where SubCategoriesID = " + SubCategoriesID;
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