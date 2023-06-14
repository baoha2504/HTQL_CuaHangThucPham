using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class BlogAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        Support sp = new Support();
        // GET: Admin/BlogAdmin
        public async Task<ActionResult> Index()
        {
            var blogs = await webApiService.GetAllBlogById();
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < blogs.Count; i++)
            {
                var customer = await webApiService.GetAccountById((int)blogs[i].CustomerID);
                customers.Add(customer);
            }
            ViewBag.customers = customers;
            ViewBag.blogs = blogs;
            return View();
        }

        public async Task<ActionResult> AddBlog()
        {
            ViewBag.id = Session["id"];
            ViewBag.name = Session["name"];
            return View();
        }

        public string RemoveVietnameseDiacritics(string input)
        {
            string[] diacritics = new string[]
            {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
            };

            for (int i = 1; i < diacritics.Length; i++)
            {
                for (int j = 0; j < diacritics[i].Length; j++)
                {
                    input = input.Replace(diacritics[i][j], diacritics[0][i - 1]);
                }
            }

            return input;
        }

        [HttpPost]
        public async Task<ActionResult> AddBlog(HttpPostedFileBase file, string title, string cusid, string content, string date)
        {
            // lấy tên ảnh
            string filename = file.FileName.ToString();
            //lấy đuôi ảnh
            string ExtensionFile = sp.GetFileExtension(filename);
            // lấy tên sản phẩm làm slug

            //lấy tên mới của ảnh + [đuôi ảnh lấy đc]
            string namefilenew = RemoveVietnameseDiacritics(title) + "." + ExtensionFile;
            //lưu ảnh vào đường đẫn
            var path = Path.Combine(Server.MapPath("~/Public/image/blog"), namefilenew);
            //nếu thư mục k tồn tại thì tạo thư mục
            var folder = Server.MapPath("~/Public/image/blog");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            file.SaveAs(path);
            System.Web.Helpers.WebImage img = new System.Web.Helpers.WebImage(path);
            img.Resize(301, 301, false);
            img.Crop(1, 1, 0, 0);
            img.Save(path);

            Blog blog = new Blog();
            blog.Image = namefilenew;
            blog.Title = title;
            blog.Content = content;
            blog.CustomerID = Int32.Parse(cusid);
            blog.DateAdded = DateTime.Parse(date);

            var blogResponse = await webApiService.CreateBlog(blog);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditBlog(string id)
        {
            var blog = await webApiService.GetBlogById(Int32.Parse(id));
            ViewBag.BlogID = id;
            ViewBag.Title = blog.Title;
            ViewBag.Content = blog.Content;
            var customer = await webApiService.GetAccountById((int)blog.CustomerID);
            ViewBag.id = customer.CustomerID;
            ViewBag.name = customer.FirstName + " " + customer.LastName;
            ViewBag.dateadded = blog.DateAdded;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditBlog(string blogid, HttpPostedFileBase file, string title, string cusid, string content, string date)
        {
            var blog = await webApiService.GetBlogById(Int32.Parse(blogid));
            file = Request.Files["file"];
            string filename = file.FileName.ToString();
            if (filename.Equals("") == false)
            {
                //lấy đuôi ảnh
                string ExtensionFile = sp.GetFileExtension(filename);
                // lấy tên sản phẩm làm slug

                //lấy tên mới của ảnh + [đuôi ảnh lấy đc]
                string namefilenew = RemoveVietnameseDiacritics(title) + "." + ExtensionFile;
                //lưu ảnh vào đường đẫn
                var path = Path.Combine(Server.MapPath("~/Public/image/blog"), namefilenew);
                //nếu thư mục k tồn tại thì tạo thư mục
                var folder = Server.MapPath("~/Public/image/blog");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                file.SaveAs(path);
                System.Web.Helpers.WebImage img = new System.Web.Helpers.WebImage(path);
                img.Resize(302, 302, false);
                img.Crop(1, 1, 1, 1);
                img.Save(path);
                blog.Image = namefilenew;
            }

            blog.Title = title;
            blog.Content = content;
            blog.CustomerID = Int32.Parse(cusid);
            blog.DateAdded = DateTime.Parse(date);

            var blogResponse = await webApiService.UpdateBlog(blog);
            return RedirectToAction("EditBlog", new { id = blogid });
        }
    }
}