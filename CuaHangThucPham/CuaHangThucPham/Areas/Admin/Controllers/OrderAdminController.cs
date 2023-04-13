using CuaHangThucPham.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        // GET: Admin/OrderAdmin
        private readonly WebApiService webApiService = new WebApiService();


        public async Task<ActionResult> Index()
        {
            var orders = await webApiService.GetAllOrder();
            List<Customer> customers = new List<Customer>();
            List<OrderStatusHistory> orderStatusHistories = new List<OrderStatusHistory>();
            for (int i = 0; i < orders.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)orders[i].CustomerID);
                customers.Add(customer);
                var orderStatusHistory = await webApiService.GetOrderStatusHistoryById((int)orders[i].OrderID);
                int a = orderStatusHistory.Count;
                orderStatusHistories.Add(orderStatusHistory[a-1]);
            }
            ViewBag.customers = customers;
            ViewBag.orders = orders;
            ViewBag.orderStatusHistories = orderStatusHistories;
            return View();
        }

        public async Task<ActionResult> Update()
        {
            var orders = await webApiService.GetAllOrder();
            List<Customer> customers = new List<Customer>();
            List<OrderStatusHistory> orderStatusHistories = new List<OrderStatusHistory>();
            for (int i = 0; i < orders.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)orders[i].CustomerID);
                customers.Add(customer);
                var orderStatusHistory = await webApiService.GetOrderStatusHistoryById((int)orders[i].OrderID);
                int a = orderStatusHistory.Count;
                orderStatusHistories.Add(orderStatusHistory[a-1]);
            }
            ViewBag.customers = customers;
            ViewBag.orders = orders;
            ViewBag.orderStatusHistories = orderStatusHistories;
            return View();
        }

        public JsonResult UpdateStatus(int id, string status)
        {
            OrderStatusHistory orderStatusHistory = new OrderStatusHistory();
            orderStatusHistory.OrderID = id;
            orderStatusHistory.OrderStatusName = status;
            orderStatusHistory.CanceledBy = "Người Bán";
            //checkDAO.InsertOrderHistory(orderStatusHistory);
            return Json(new
            {
                status = true
            });
        }
    }
}