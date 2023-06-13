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
        public async Task<ActionResult> Reply()
        {
            return View();
        }
    }
}