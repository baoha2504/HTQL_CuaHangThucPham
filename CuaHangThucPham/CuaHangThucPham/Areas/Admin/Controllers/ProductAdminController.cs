using CuaHangThucPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuaHangThucPham.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly WebApiService webApiService = new WebApiService();
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
            return View();
        }
    }
}