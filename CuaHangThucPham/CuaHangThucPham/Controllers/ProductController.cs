using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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

            List<Review> rv = new List<Review>();
            Review rev = new Review();
            int dembinhluan = 0;
            rev = null;
            query = "Select * from Review where ProductID = " + ID;
            var reviewCus = ctx.Reviews.SqlQuery(query).ToList();
            dembinhluan += reviewCus.Count;
            for (int i = 0; i < reviewCus.Count; i++)
            {
                query = "Select * from Review where Reply = " + reviewCus[i].ReviewID;
                var reviewAdmin = ctx.Reviews.SqlQuery(query).ToList();
                if(reviewAdmin.Count > 0)
                {
                    rv.Add(reviewAdmin[0]);
                    dembinhluan++;
                } else
                {
                    rv.Add(rev);
                }
            }
            ViewBag.reviewCus = reviewCus;
            ViewBag.rv = rv;
            ViewBag.dembinhluan = dembinhluan;
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
            }
            else if (name == string.Empty && price != string.Empty)
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

        [HttpPost]
        public ActionResult AddReview(string idcus, string idproduct, string inputreview, string rating)
        {
            Review review = new Review();
            review.ProductID = Int32.Parse(idproduct);
            review.CustomerID = Int32.Parse(idcus);
            review.NumStar = Int32.Parse(rating);
            review.Comment = inputreview;
            review.DateAdded = DateTime.Now;
            ctx.Reviews.Add(review);
            ctx.SaveChanges();
            return RedirectToAction("DetailProduct", new { id = idproduct });
        }
    }
}