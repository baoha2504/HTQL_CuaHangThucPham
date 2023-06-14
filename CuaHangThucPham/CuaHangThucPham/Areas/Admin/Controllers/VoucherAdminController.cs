using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class VoucherAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        // GET: Admin/VoucherAdmin
        public async Task<ActionResult> Index()
        {
            var vouchers = await webApiService.GetAllVoucher();
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < vouchers.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)vouchers[i].CustomerID);
                customers.Add(customer);
            }
            ViewBag.customers = customers;
            ViewBag.vouchers = vouchers;
            return View();
        }

        public async Task<ActionResult> AddVoucher()
        {
            ViewBag.name = Session["name"];
            ViewBag.id = Session["id"];
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddVoucher(string cusid, string makhuyenmai, int phantramgiam, int giamlonnhat, int donhangtoithieu, string thoigian)
        {
            Voucher voucher = new Voucher();
            voucher.VoucherCode = makhuyenmai;
            voucher.CustomerID = Int32.Parse(cusid);
            voucher.SalePercent = phantramgiam;
            voucher.MaximumDis = giamlonnhat;
            voucher.MiximunVal = donhangtoithieu;
            voucher.Expiry = DateTime.Parse(thoigian);
            var voucherResponse = await webApiService.CreateVoucher(voucher);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditVoucher(string id)
        {
            var voucher = await webApiService.GetVoucherById(Int32.Parse(id));
            ViewBag.VoucherID = voucher.VoucherID;
            ViewBag.VoucherCode = voucher.VoucherCode;
            ViewBag.SalePercent = voucher.SalePercent;
            ViewBag.MaximumDis = voucher.MaximumDis;
            ViewBag.MiximunVal = voucher.MiximunVal;
            ViewBag.Expiry = voucher.Expiry;

            var customer = await webApiService.GetAccountById((int)voucher.CustomerID);
            ViewBag.name = customer.FirstName + " " + customer.LastName;
            ViewBag.id = customer.CustomerID;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditVoucher(string voucherid, string cusid, string makhuyenmai, int phantramgiam, int giamlonnhat, int donhangtoithieu, string thoigian)
        {
            Voucher voucher = new Voucher();
            voucher.VoucherCode = makhuyenmai;
            voucher.CustomerID = Int32.Parse(cusid);
            voucher.SalePercent = phantramgiam;
            voucher.MaximumDis = giamlonnhat;
            voucher.MiximunVal = donhangtoithieu;
            voucher.Expiry = DateTime.Parse(thoigian);
            var voucherResponse = await webApiService.UpdateVoucher(voucher);
            return RedirectToAction("EditVoucher", new { id = voucherid });
        }
    }
}