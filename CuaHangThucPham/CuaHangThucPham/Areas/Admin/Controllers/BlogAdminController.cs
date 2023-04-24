using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class BlogAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/BlogAdmin
        public async Task<ActionResult> Index()
        {
            var blogs = await webApiService.GetAllBlogById();
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < blogs.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)blogs[i].CustomerID);
                customers.Add(customer);
            }
            ViewBag.customers = customers;
            ViewBag.blogs = blogs;
            return View();
        }
    }
}