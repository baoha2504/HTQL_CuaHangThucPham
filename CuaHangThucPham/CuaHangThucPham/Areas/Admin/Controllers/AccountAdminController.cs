using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/Admin
        public async Task<ActionResult> Admin()
        {
            var customers = await webApiService.GetAllAccount();
            for (int i = customers.Count - 1; i >= 0; i--)
            {
                if (customers[i].Access != 1)
                {
                    customers.Remove(customers[i]);
                }
            }
            ViewBag.customers = customers;
            return View();
        }

        // GET: Admin/Staff
        public async Task<ActionResult> Staff()
        {
            var customers = await webApiService.GetAllAccount();
            for (int i = customers.Count - 1; i >= 0; i--)
            {
                if (customers[i].Access != 2 && customers[i].Access != 3)
                {
                    customers.Remove(customers[i]);
                }
            }
            ViewBag.customers = customers;
            return View();
        }

        // GET: Admin/Customer
        public async Task<ActionResult> Customer()
        {
            var customers = await webApiService.GetAllAccount();
            for (int i = customers.Count - 1; i >= 0; i--)
            {
                if (customers[i].Access != 4)
                {
                    customers.Remove(customers[i]);
                }
            }
            ViewBag.customers = customers;
            return View();
        }
    }
}