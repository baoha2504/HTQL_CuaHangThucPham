using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class OrderController : Controller
    {
        string query = "";
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        // GET: Order
        public ActionResult Index()
        {
            query = "select * from dbo.[Order], OrderStatusHistory " +
                "where dbo.[Order].OrderID = OrderStatusHistory.OrderID " +
                "and OrderStatusHistory.OrderStatusName = N'Đang Chờ Xác Nhận' " +
                "and dbo.[Order].CustomerID = '" + Session["id"] +"'";
            var dangchoxacnhan = ctx.Orders.SqlQuery(query).ToList();
            ViewBag.dangchoxacnhan = dangchoxacnhan;

            query = "select * from dbo.[Order], OrderStatusHistory " +
                "where dbo.[Order].OrderID = OrderStatusHistory.OrderID " +
                "and OrderStatusHistory.OrderStatusName = N'Đang Giao Hàng' " +
                "and dbo.[Order].CustomerID = '" + Session["id"] + "'";
            var danggiaohang = ctx.Orders.SqlQuery(query).ToList();
            ViewBag.danggiaohang = danggiaohang;

            query = "select * from dbo.[Order], OrderStatusHistory " +
                "where dbo.[Order].OrderID = OrderStatusHistory.OrderID " +
                "and OrderStatusHistory.OrderStatusName = N'Đã Giao Hàng' " +
                "and dbo.[Order].CustomerID = '" + Session["id"] + "'";
            var dagiaohang = ctx.Orders.SqlQuery(query).ToList();
            ViewBag.dagiaohang = dagiaohang;

            query = "select * from dbo.[Order], OrderStatusHistory " +
                "where dbo.[Order].OrderID = OrderStatusHistory.OrderID " +
                "and OrderStatusHistory.OrderStatusName = N'Đã Hủy' " +
                "and dbo.[Order].CustomerID = '" + Session["id"] + "'";
            var dahuy = ctx.Orders.SqlQuery(query).ToList();
            ViewBag.dahuy = dahuy;
            return View();
        }

        public ActionResult OrderInformation(int orderid)
        {
            query = "select * from OrderDetail, dbo.[Order] " +
                "where dbo.[Order].OrderID = OrderDetail.OrderID " +
                "and dbo.[Order].CustomerID = '"+ Session["id"] + "' " +
                "and OrderDetail.OrderID = '"+ orderid + "'";
            var OrderDetail = ctx.OrderDetails.SqlQuery(query).ToList();
            ViewBag.OrderDetail = OrderDetail;

            query = "select * from OrderStatusHistory, dbo.[Order] " +
                "where dbo.[Order].OrderID = OrderStatusHistory.OrderID " +
                "and dbo.[Order].CustomerID = '"+ Session["id"] + "' " +
                "and OrderStatusHistory.OrderID = '"+ orderid + "'";
            var OrderStatus = ctx.OrderStatusHistories.SqlQuery(query).ToList();
            ViewBag.OrderStatus = OrderStatus;
            int sum = 0;
            foreach(var item in OrderDetail)
            {
                sum += (int)item.Quantity * (int)item.Price;
            }
            ViewBag.sum = sum;
            return View();
        }
    }
}