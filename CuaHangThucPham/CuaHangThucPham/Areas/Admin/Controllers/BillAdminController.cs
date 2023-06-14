using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<ActionResult> ViewBill(string id)
        {
            Bill bill = new Bill();
            List<Product> prd = new List<Product>();
            var bills = await webApiService.GetAllBill(0);
            
            for (int i = 0; i < bills.Count; i++)
            {
                if (bills[i].BillID == Int32.Parse(id))
                {
                    bill = bills[i];
                }
            }

            var customer = await webApiService.GetAccountById((int)bill.CustomerID);
            var billDetails = await webApiService.GetAllBillDetailByBillId(bill.BillID);
            var products = await webApiService.GetAllProduct();
            for (int i = 0; i < billDetails.Count; i++)
            {
                for (int j = 0; j < products.Count; j++)
                {
                    if (billDetails[i].ProductID == products[j].ProductID)
                    {
                        prd.Add(products[j]);
                    }
                }
            }
            ViewBag.billDetails = billDetails;
            ViewBag.BillID = bill.BillID;
            ViewBag.StaffName = customer.FirstName + " " + customer.LastName;
            ViewBag.OrderDate = bill.OrderDate;
            ViewBag.Total = bill.Total;
            ViewBag.prd = prd;
            return View();
        }
    }
}