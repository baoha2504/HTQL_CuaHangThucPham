using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class VoucherAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/VoucherAdmin
        public async Task<ActionResult> Index()
        {
            var vouchers = await webApiService.GetAllVoucher();
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < vouchers.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)vouchers[i].CustomerID);
                customers.Add(customer);
            }
            ViewBag.customers = customers;
            ViewBag.vouchers = vouchers;
            return View();
        }

        public async Task<ActionResult> AddVoucher()
        {
            return View();
        }
    }
}