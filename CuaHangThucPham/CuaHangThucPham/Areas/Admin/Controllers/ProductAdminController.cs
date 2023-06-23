using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
        Support sp = new Support();
        // GET: Admin/ProductAdmin
        public async Task<ActionResult> Index()
        {
            var products = await webApiService.GetAllProduct();
            List<SubCategory> subCategories = new List<SubCategory>();
            for (int i = 0; i < products.Count; i++)
            {
                var subCategory = await webApiService.GetSubCategoriesById((int)products[i].SubCategoriesID);
                subCategories.Add(subCategory);
            }
            ViewBag.products = products;
            ViewBag.subCategories = subCategories;
            ViewBag.menu = 4;
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

        public async Task<ActionResult> AddProduct()
        {
            var subCategories = await webApiService.GetAllSubCategory();
            ViewBag.subCategories = subCategories;
            ViewBag.menu = 4;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(int subcate, HttpPostedFileBase file, string productname, string brand, string model, string suppiler, string pricenew, string priceold, string summary, string area, string date)
        {
            // lấy tên ảnh
            string filename = file.FileName.ToString();
            //lấy đuôi ảnh
            string ExtensionFile = sp.GetFileExtension(filename);
            // lấy tên sản phẩm làm slug

            //lấy tên mới của ảnh + [đuôi ảnh lấy đc]
            string namefilenew = RemoveVietnameseDiacritics(productname) + "." + ExtensionFile;
            //lưu ảnh vào đường đẫn
            var path = Path.Combine(Server.MapPath("~/Public/image/product"), namefilenew);
            //nếu thư mục k tồn tại thì tạo thư mục
            var folder = Server.MapPath("~/Public/image/product");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            file.SaveAs(path);
            System.Web.Helpers.WebImage img = new System.Web.Helpers.WebImage(path);
            img.Resize(301, 301, false);
            img.Crop(1, 1, 0, 0);
            img.Save(path);
            Product product = new Product();
            product.ProductName = productname;
            product.SubCategoriesID = subcate;
            product.Brand = brand;
            product.Model = model;
            product.Suppiler = suppiler;
            product.PriceNew = int.Parse(pricenew.Replace(",", ""));
            product.PriceOld = int.Parse(priceold.Replace(",", ""));
            product.Summary = summary;
            product.Description = area;
            product.Status = 1;
            product.Image = namefilenew;
            product.DateAdded = DateTime.Parse(date);

            var productResponse = await webApiService.CreateProduct(product);

            ViewBag.alert = "Thêm thành công";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditProduct(string id)
        {
            var product = await webApiService.GetProductById(Int32.Parse(id));
            ViewBag.ProductId = product.ProductID;
            ViewBag.SubCategoriesId = product.SubCategoriesID;
            var subCategory = await webApiService.GetSubCategoriesById((int)product.SubCategoriesID);
            ViewBag.SubCategoryName = subCategory.SubCategoriesName;
            ViewBag.ProductName = product.ProductName;
            ViewBag.Summary = product.Summary;
            ViewBag.Description = product.Description;
            ViewBag.Image = product.Image;
            ViewBag.PriceNew = product.PriceNew;
            ViewBag.PriceOld = product.PriceOld;
            ViewBag.Brand = product.Brand;
            ViewBag.Model = product.Model;
            ViewBag.Suppiler = product.Suppiler;
            ViewBag.Status = product.Status;
            ViewBag.DateAdded = product.DateAdded;
            ViewBag.menu = 4;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(string prdid, int subcate, HttpPostedFileBase file, string productname, string brand, string model, string suppiler, string pricenew, string priceold, string summary, string area)
        {
            var product = await webApiService.GetProductById(Int32.Parse(prdid));
            file = Request.Files["file"];
            string filename = file.FileName.ToString();
            if (filename.Equals("") == false)
            {
                //lấy đuôi ảnh
                string ExtensionFile = sp.GetFileExtension(filename);
                // lấy tên sản phẩm làm slug

                //lấy tên mới của ảnh + [đuôi ảnh lấy đc]
                string namefilenew = RemoveVietnameseDiacritics(productname) + "." + ExtensionFile;
                //lưu ảnh vào đường đẫn
                var path = Path.Combine(Server.MapPath("~/Public/image/product"), namefilenew);
                //nếu thư mục k tồn tại thì tạo thư mục
                var folder = Server.MapPath("~/Public/image/product");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                file.SaveAs(path);
                System.Web.Helpers.WebImage img = new System.Web.Helpers.WebImage(path);
                img.Resize(302, 302, false);
                img.Crop(1, 1, 1, 1);
                img.Save(path);
                product.Image = namefilenew;
            }
            product.ProductName = productname;
            product.SubCategoriesID = subcate;
            product.Brand = brand;
            product.Model = model;
            product.Suppiler = suppiler;
            product.PriceNew = int.Parse(pricenew.Replace(",", ""));
            product.PriceOld = int.Parse(priceold.Replace(",", ""));
            product.Summary = summary;
            product.Description = area;

            var productResponse = await webApiService.UpdateProduct(product);

            return RedirectToAction("EditProduct", new { id = prdid });
        }
    }
}