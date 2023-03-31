using CuaHangThucPham.Library;
using CuaHangThucPham.Models;
using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class AccountController : Controller
    {
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        CuaHangThucPham.Support.Support support = new CuaHangThucPham.Support.Support();
        string query = "";
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string email, string pass)
        {
            query = "select * from Customer where Email = N'" + email + "' and PassWord = N'" + support.EncodePassword(pass) + "'";
            var customers = ctx.Customers.SqlQuery(query).ToList();
            if (customers.Count == 1)
            {
                TempData["Error"] = "Đăng nhập thành công";
                Message.set_flash("Đăng nhập thành công", "Thành công");
                Session["id"] = customers[0].CustomerID;
                Session["name"] = customers[0].FirstName + " " + customers[0].LastName;
                Session["email"] = email;
                Session["pass"] = pass;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Kiểm tra lại mật khẩu";
                Message.set_flash("Kiểm tra lại mật khẩu", "error");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["name"] = null;
            Session["email"] = null;
            Session["pass"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult Affiliate()
        {
            return View();
        }
    }
}