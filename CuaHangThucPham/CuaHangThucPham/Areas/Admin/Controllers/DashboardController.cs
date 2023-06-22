using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/Dashboard
        public async Task<ActionResult> Index()
        {
            DateTime now = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            DateTime lastDayOfMonth = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1);
            List<Review> rv = new List<Review>();
            List<OrderStatusHistory> odshs = new List<OrderStatusHistory>();
            List<Bill> bl0 = new List<Bill>();
            List<Bill> bl1 = new List<Bill>();
            List<Customer> cus0 = new List<Customer>();
            List<Customer> cus1 = new List<Customer>();

            int tongdoanhthu = 0;
            int tongchi = 0;
            int demchuaxuly = 0;
            int khachhangbinhluan = 0;
            int phanhoibinhluan = 0;
            int tylephanhoi = 0;
            int demthongbao = 0;

            // Hiển thị số trên 4 ô đầu
            var orders = await webApiService.GetAllOrder();
            for (int i = 0; i < orders.Count; i++)
            {
                var orderStatusHistories = await webApiService.GetOrderStatusHistoryById(orders[i].OrderID);
                var orderStatusHistory = orderStatusHistories[orderStatusHistories.Count - 1];
                if (orderStatusHistory.OrderStatusName == "Đã Giao Hàng" && orderStatusHistory.DateAdd >= firstDayOfMonth && orderStatusHistory.DateAdd <= lastDayOfMonth)
                {
                    tongdoanhthu += (int)orders[i].Total;
                }
                if (orderStatusHistory.OrderStatusName == "Đang Chờ Xác Nhận")
                {
                    demchuaxuly++;
                }
            }

            demchuaxuly = 100 - (int)Math.Round((double)demchuaxuly * 100 / orders.Count);

            // 0 la ban hang
            var bill0 = await webApiService.GetAllBill(0);
            for (int i = 0; i < bill0.Count; i++)
            {
                if (bill0[i].OrderDate >= firstDayOfMonth && bill0[i].OrderDate <= lastDayOfMonth)
                {
                    tongdoanhthu += (int)bill0[i].Total;
                }
            }

            demthongbao = 0;
            for (int i = bill0.Count - 1; i >= 0; i--)
            {
                if (demthongbao != 3)
                {
                    var cus = await webApiService.GetAccountById((int)bill0[i].CustomerID);
                    cus0.Add(cus);
                    bl0.Add(bill0[i]);
                    demthongbao++;
                }
            }

            // 1 la nhap hang
            var bill1 = await webApiService.GetAllBill(1);
            for (int i = 0; i < bill1.Count; i++)
            {
                if (bill1[i].OrderDate >= firstDayOfMonth && bill1[i].OrderDate <= lastDayOfMonth)
                {
                    tongchi += (int)bill1[i].Total;
                }
            }

            demthongbao = 0;
            for (int i = bill1.Count - 1; i >= 0; i--)
            {
                if (demthongbao != 3)
                {
                    var cus = await webApiService.GetAccountById((int)bill1[i].CustomerID);
                    cus1.Add(cus);
                    bl1.Add(bill1[i]);
                    demthongbao++;
                }
            }

            var reviews = await webApiService.GetAllReview();
            demthongbao = 0;
            for (int i = reviews.Count - 1; i >= 0; i--)
            {
                if (reviews[i].Reply == null)
                {
                    khachhangbinhluan++;
                }
                else
                {
                    phanhoibinhluan++;
                }
                if (demthongbao != 3)
                {
                    rv.Add(reviews[i]);
                    demthongbao++;
                }
            }

            tylephanhoi = (int)Math.Round((double)phanhoibinhluan * 100 / khachhangbinhluan);

            var odsh = await webApiService.GetAllOrderStatusHistory();
            demthongbao = 0;
            for(int i = odsh.Count - 1; i >= 0; i--)
            {
                if (demthongbao != 3)
                {
                    odshs.Add(odsh[i]);
                    demthongbao++;
                }
            }

            ViewBag.tongdoanhthu = tongdoanhthu;
            ViewBag.tongchi = tongchi;
            ViewBag.demchuaxuly = demchuaxuly;
            ViewBag.tylephanhoi = tylephanhoi;
            ViewBag.rv = rv;
            ViewBag.odshs = odshs;
            ViewBag.bl0 = bl0;
            ViewBag.bl1 = bl1;
            ViewBag.cus0 = cus0;
            ViewBag.cus1 = cus1;

            return View();
        }
    }
}