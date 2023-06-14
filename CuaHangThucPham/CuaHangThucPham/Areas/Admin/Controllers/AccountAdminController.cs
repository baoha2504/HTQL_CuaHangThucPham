using System;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult> UpdateStatusStaff(string id, int prohibit)
        {
            var customer = await webApiService.GetAccountById(Int32.Parse(id));
            if (customer != null)
            {
                customer.Prohibit = prohibit;
                var responseAccount = await webApiService.UpdateAccount(customer);
            }
            return RedirectToAction("Staff");
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

        [HttpGet]
        public async Task<ActionResult> UpdateStatusCustomer(string id, int prohibit)
        {
            var customer = await webApiService.GetAccountById(Int32.Parse(id));
            if (customer != null)
            {
                customer.Prohibit = prohibit;
                var responseAccount = await webApiService.UpdateAccount(customer);
            }
            return RedirectToAction("Customer");
        }
    }
}