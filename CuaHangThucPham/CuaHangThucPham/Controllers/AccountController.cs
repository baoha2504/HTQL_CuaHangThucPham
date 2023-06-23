using CuaHangThucPham.Models;
using System.Linq;
using System.Web.Mvc;

namespace CuaHangThucPham.Controllers
{
    public class AccountController : Controller
    {
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        CuaHangThucPham.Support support = new CuaHangThucPham.Support();
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
                if (customers[0].Access == 1 && customers[0].Prohibit == 1)
                {
                    Session["id"] = customers[0].CustomerID;
                    Session["name"] = customers[0].FirstName + " " + customers[0].LastName;
                    Session["email"] = email;
                    Session["pass"] = pass;
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (customers[0].Access == 4 && customers[0].Prohibit == 1)
                {
                    TempData["Error"] = null;
                    Message.set_flash("Đăng nhập thành công", "Thành công");
                    Session["id"] = customers[0].CustomerID;
                    Session["name"] = customers[0].FirstName + " " + customers[0].LastName;
                    Session["email"] = email;
                    Session["pass"] = pass;
                    return RedirectToAction("Index", "Home");
                }
                else if (customers[0].Access != 1 && customers[0].Access != 4 && customers[0].Prohibit == 1)
                {
                    TempData["Error"] = "Tài khoản của bạn không thể đăng nhập ở đây";
                    Message.set_flash("Tài khoản của bạn không thể đăng nhập ở đây", "error");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    TempData["Error"] = "Tài khoản đã bị khóa";
                    Message.set_flash("Tài khoản đã bị khóa", "error");
                    return RedirectToAction("Login", "Account");
                }
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
            if (Session["id"] != null)
            {
                query = "select * from Customer where CustomerID = N'" + Session["id"] +"'";
                var customers = ctx.Customers.SqlQuery(query).ToList();
                ViewBag.customers = customers;
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateAccount(string firstname, string lastname, string email, string telephone, string company, string address_1, string address_2, string city)
        {
            query = "select * from Customer where CustomerID = N'" + Session["id"] + "'";
            int id = (int)Session["id"];
            var customers = ctx.Customers.FirstOrDefault(m => m.CustomerID == id);
            customers.FirstName = firstname;
            customers.LastName = lastname;
            customers.Email = email;
            customers.Phone = telephone;
            customers.Company = company;
            customers.Address1 = address_1;
            customers.Address2 = address_2;
            customers.City = city;
            ctx.SaveChanges();
            Message.set_flash("Cập nhật thông tin thành công", "success");
            return RedirectToAction("Register");
        }
        public bool CheckExistEmail(string email)
        {
            query = "select * from Customer where email = N'" + email + "'";
            var customers = ctx.Customers.SqlQuery(query).ToList();
            if (customers.Count != 0) // tồn tại => sai
            {
                return false;
            }
            return true; // k tồn tại
        }
        [HttpPost]
        public ActionResult CreateAccount(string firstname, string lastname, string email, string telephone, string company, string address_1, string address_2, string city, string password, string confirm)
        {
            if (password != confirm)
            {
                TempData["Error"] = "Mật khẩu nhập lại không khớp";
                Message.set_flash("Mật khẩu nhập lại không khớp", "error");
            }
            else if (!CheckExistEmail(email)) // false
            {

                TempData["Error"] = "Địa chỉ Email đã được sử dụng";
                Message.set_flash("Địa chỉ Email đã được sử dụng", "error");
            }
            else
            {
                Customer cus = new Customer();
                cus.FirstName = firstname;
                cus.LastName = lastname;
                cus.Email = email;
                cus.Phone = telephone;
                cus.Company = company;
                cus.Address1 = address_1;
                cus.Address2 = address_2;
                cus.City = city;
                cus.PassWord = support.EncodePassword(password);
                cus.Access = 4;
                cus.Prohibit = 1;
                try
                {
                    ctx.Customers.Add(cus);
                    ctx.SaveChanges();
                    TempData["Succes"] = "Thành Công";
                    Message.set_flash("Đăng ký thành công", "success");
                }
                catch
                {
                    TempData["Error"] = "Thất Bại";
                    Message.set_flash("Thất Bại", "error");
                }
            }
            return RedirectToAction("Register");
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