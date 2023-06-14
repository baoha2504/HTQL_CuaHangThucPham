using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                orderStatusHistories.Add(orderStatusHistory[a - 1]);
            }
            ViewBag.customers = customers;
            ViewBag.orders = orders;
            ViewBag.orderStatusHistories = orderStatusHistories;
            return View();
        }

        public async Task<ActionResult> ViewOrder(string id)
        {
            List<Product> prd = new List<Product>();
            var order = await webApiService.GetOrderById(Int32.Parse(id));
            var customer = await webApiService.GetAccountById((int)order.CustomerID);
            var shipping = await webApiService.GetShippingById((int)order.ShippingID);
            var payment = await webApiService.GetPaymentById((int)order.PaymentID);
            var orderStatusHistories = await webApiService.GetOrderStatusHistoryById((int)order.OrderID);
            var orderDetails = await webApiService.GetOrderDetailById((int)order.OrderID);
            var products = await webApiService.GetAllProduct();
            for(int i = 0; i < orderDetails.Count; i++)
            {
                for(int j = 0; j < products.Count; j++)
                {
                    if (orderDetails[i].ProductID == products[j].ProductID)
                    {
                        prd.Add(products[j]);
                    }
                }
            }
            ViewBag.CustomerName = customer.FirstName + " " + customer.LastName;
            ViewBag.DateAdd = order.DateAdd;
            ViewBag.ShippingAddress = order.ShippingAddress;
            ViewBag.Name = order.Name;
            ViewBag.Phone = order.Phone;
            ViewBag.Note = order.Note;
            ViewBag.ShippingFee = order.ShippingFee;
            ViewBag.Discount = order.Discount;
            ViewBag.Total = order.Total;
            ViewBag.shipping = shipping.ShippingName;
            ViewBag.payment = payment.PaymentName;
            ViewBag.orderStatusHistoryName = orderStatusHistories[orderStatusHistories.Count - 1].OrderStatusName;
            ViewBag.orderDetails = orderDetails;
            ViewBag.prd = prd;
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
                orderStatusHistories.Add(orderStatusHistory[a - 1]);
            }
            ViewBag.customers = customers;
            ViewBag.orders = orders;
            ViewBag.orderStatusHistories = orderStatusHistories;
            return View();
        }

        // 1. Đã Xác Nhận
        // 2. Đang Giao Hàng
        // 3. Đã Giao Hàng
        // 4. Hủy
        public async Task<ActionResult> UpdateStatus(int id, int status)
        {
            OrderStatusHistory orderStatusHistory = new OrderStatusHistory();
            orderStatusHistory.DateAdd = DateTime.Now;
            orderStatusHistory.OrderID = id;
            if (status == 1)
            {
                orderStatusHistory.OrderStatusName = "Đã Xác Nhận";
            } 
            else if (status == 2)
            {
                orderStatusHistory.OrderStatusName = "Đang Giao Hàng";
            }
            else if (status == 3)
            {
                orderStatusHistory.OrderStatusName = "Đã Giao Hàng";
            }
            else if (status == 4)
            {
                orderStatusHistory.OrderStatusName = "Đã hủy";
            }

            orderStatusHistory.CanceledBy = "Người Bán";
            orderStatusHistory.CanceledBy = (string)Session["name"];
            var responseOrderStatusHistory = await webApiService.CreateOrderStatusHistory(orderStatusHistory);
            return RedirectToAction("Update");
        }
    }
}