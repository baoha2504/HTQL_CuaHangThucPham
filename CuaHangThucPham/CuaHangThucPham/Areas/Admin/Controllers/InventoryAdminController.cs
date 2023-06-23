using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class InventoryAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/Inventory
        public async Task<ActionResult> Index()
        {
            var inventories = await webApiService.GetAllInventory();
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();
            for (int i = inventories.Count - 1; i >= 0; i--)
            {
                if (inventories[i].ExpirationDate > DateTime.Now)// còn hạn
                {
                    var customer = await webApiService.GetAccountById((int)inventories[i].CustomerID);
                    customers.Add(customer);
                    var product = await webApiService.GetProductById((int)inventories[i].ProductID);
                    products.Add(product);
                }
                else
                {
                    inventories.Remove(inventories[i]);
                }
            }
            ViewBag.customers = customers;
            ViewBag.products = products;
            ViewBag.inventories = inventories;
            ViewBag.menu = 3;
            return View();
        }
        public async Task<ActionResult> History()
        {
            var inventories = await webApiService.GetAllInventory();
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();
            for (int i = inventories.Count - 1; i >= 0; i--)
            {
                var customer = await webApiService.GetAccountById((int)inventories[i].CustomerID);
                customers.Add(customer);
                var product = await webApiService.GetProductById((int)inventories[i].ProductID);
                products.Add(product);
            }
            ViewBag.customers = customers;
            ViewBag.products = products;
            ViewBag.inventories = inventories;
            ViewBag.menu = 3;
            return View();
        }
        public async Task<ActionResult> Expired()
        {
            var inventories = await webApiService.GetAllInventory();
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();
            for (int i = inventories.Count - 1; i >= 0; i--)
            {
                if (inventories[i].ExpirationDate <= DateTime.Now)// hết hạn
                {
                    var customer = await webApiService.GetAccountById((int)inventories[i].CustomerID);
                    customers.Add(customer);
                    var product = await webApiService.GetProductById((int)inventories[i].ProductID);
                    products.Add(product);
                }
                else
                {
                    inventories.Remove(inventories[i]);
                }
            }
            ViewBag.customers = customers;
            ViewBag.products = products;
            ViewBag.inventories = inventories;
            ViewBag.menu = 3;
            return View();
        }
    }
}