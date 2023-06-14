using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class ReviewAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/ReviewAdmin
        public async Task<ActionResult> Index()
        {
            var reviews = await webApiService.GetAllReview();
            for(int i = reviews.Count-1; i >=0 ; i--)
            {
                if (reviews[i].Reply != null)
                {
                    reviews.Remove(reviews[i]);
                }
            }
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();
            for (int i = 0; i < reviews.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)reviews[i].CustomerID);
                customers.Add(customer);
                var product = await webApiService.GetProductById((int)reviews[i].CustomerID);
                products.Add(product);
            }
            ViewBag.customers = customers;
            ViewBag.products = products;
            ViewBag.reviews = reviews;
            return View();
        }

        public async Task<ActionResult> Reply(string id)
        {
            var review = await webApiService.GetReviewById(Int32.Parse(id));
            int dem = 0;
            var reviews = await webApiService.GetAllReview();
            Review reviewReply = new Review();
            for(int i = 0; i < reviews.Count; i++)
            {
                if(reviews[i].Reply == review.ReviewID)
                {
                    reviewReply = reviews[i];
                    dem++;
                }
            }
            if (dem == 0)
            {
                var customer = await webApiService.GetAccountById((int)review.CustomerID);
                ViewBag.ReviewId = review.ReviewID;
                ViewBag.Comment = review.Comment;
                ViewBag.DateAdded = review.DateAdded;
                ViewBag.id = Session["id"];
                ViewBag.name = Session["name"];
                ViewBag.CustomerName = customer.FirstName + " " + customer.LastName;
                return View();
            } else
            {
                var customer = await webApiService.GetAccountById((int)reviewReply.CustomerID);
                ViewBag.ReviewId = review.ReviewID;
                ViewBag.Comment = review.Comment;
                ViewBag.DateAdded = review.DateAdded;
                ViewBag.id = Session["id"];
                ViewBag.name = Session["name"];
                ViewBag.CustomerName = customer.FirstName + " " + customer.LastName;
                ViewBag.CommentAdmin = reviewReply.Comment;
                ViewBag.DateAddedAdmin = reviewReply.DateAdded;
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Reply(string adminid, string reviewid, string admincontent, string admindate)
        {
            Review review = new Review();
            review.CustomerID = Int32.Parse(adminid);
            review.Comment = admincontent;
            review.DateAdded = DateTime.Parse(admindate);
            review.Reply = Int32.Parse(reviewid);

            var blogResponse = await webApiService.CreateReview(review);
            return RedirectToAction("Reply", new { id = reviewid });
        }
    }
}