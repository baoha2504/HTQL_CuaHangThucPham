using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class CustomerAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/CustomerAdmin

        public async Task<ActionResult> Index()
        {
            var customers = await webApiService.GetAllAccount();
            for(int i = customers.Count-1; i >= 0; i--)
            {
                if(customers[i].Access != 4)
                {
                    customers.Remove(customers[i]);
                }
            }
            ViewBag.customers = customers;
            ViewBag.menu = 8;
            return View();
        }
    }
}