using CuaHangThucPham.Library;
using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        string query = "";
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                query = "select * from Customer where CustomerID = N'" + Session["id"] + "'";
                var customers = ctx.Customers.SqlQuery(query).ToList();
                ViewBag.customers = customers;
                query = "select * from Cart where CustomerID = N'" + Session["id"] + "'";
                var carts = ctx.Carts.SqlQuery(query).ToList();
                ViewBag.Carts = carts;
                return View();
            } else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public JsonResult Payment(string shipid, string paymentid, string shipadd, string discounting, string total, string note, string name, string phone)
        {

            Order order = new Order();
            OrderStatusHistory orderStatusHistory = new OrderStatusHistory();
            order.CustomerID = (int)(Session["id"]);
            order.ShippingID = Int32.Parse(shipid);
            order.PaymentID = Int32.Parse(paymentid);
            order.ShippingAddress = shipadd;
            order.Name = name;
            order.Phone = phone;
            order.Note = note;
            order.DateAdd = DateTime.Now;
            if (discounting != string.Empty)
            {
                order.Discount = Int32.Parse(discounting);
            }
            else
            {
                order.Discount = 0;
            }
            if (Int32.Parse(shipid) == 2)
            {
                order.ShippingFee = 30000;
                order.Total = Int32.Parse(total) + order.ShippingFee;
            }
            else
            {
                order.ShippingFee = 0;
                order.Total = Int32.Parse(total);
            }
            ctx.Orders.Add(order);
            ctx.SaveChanges();
            orderStatusHistory.OrderStatusName = "Đang Chờ Xác Nhận";
            orderStatusHistory.DateAdd = DateTime.Now;
            orderStatusHistory.OrderID = order.OrderID;
            ctx.OrderStatusHistories.Add(orderStatusHistory);
            ctx.SaveChanges();

            query = "select * from Cart where CustomerID = N'" + Session["id"] + "'";
            var carts = ctx.Carts.SqlQuery(query).ToList();
            for (int i = 0; i < carts.Count(); i++)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderID = order.OrderID;
                orderDetail.ProductID = carts[i].ProductID;
                orderDetail.Quantity = carts[i].Quantity;
                orderDetail.Price = carts[i].Product.PriceNew;
                ctx.OrderDetails.Add(orderDetail);
                ctx.Carts.Remove(carts[i]);
                ctx.SaveChanges();
            }
            Session["SessionCart"] = new List<Cart_item>();

            ctx.SaveChanges();
            Session["discount"] = null;
            Session["priceAfterDiscount"] = null;
            Session["vouchercode"] = null;
            Message.set_flash("Đặt hàng thành công", "success");
            return Json(new
            {
                status = true

            });
        }
    }
}