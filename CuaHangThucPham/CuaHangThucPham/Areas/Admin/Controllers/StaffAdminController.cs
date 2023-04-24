using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class StaffAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/Staff
        public async Task<ActionResult> Index()
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
    }
}