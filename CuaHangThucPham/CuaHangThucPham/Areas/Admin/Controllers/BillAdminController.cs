using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class BillAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/Bill
        public async Task<ActionResult> Index()
        {
            var bills = await webApiService.GetAllBill(0);
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < bills.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)bills[i].CustomerID);
                customers.Add(customer);
            }
            ViewBag.bills = bills;
            ViewBag.customers = customers;
            return View();
        }
    }
}