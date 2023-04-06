using CuaHangThucPham.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CuaHangThucPham.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        GroceryStoreDbContext ctx = new GroceryStoreDbContext();
        string query = "";
        public const string SessionCart = "SessionCart";
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                var sessionCart = Session[SessionCart];
                var list = new List<Cart_item>();
                Cart_item cartitem = new Cart_item();
                query = "select * from Cart where CustomerID = N'" + Session["id"] + "'";
                var carts = ctx.Carts.SqlQuery(query).ToList();
                ViewBag.Carts = carts;

                for (int i = 0; i < carts.Count; i++)
                {
                    cartitem.product = carts[i].Product;
                    cartitem.Quantity = (int)carts[i].Quantity;
                    cartitem.ProductID = (int)carts[i].ProductID;
                    cartitem.Price = (int)carts[i].Product.PriceNew;
                    list.Add(cartitem);
                }
                Session[SessionCart] = (List<Cart_item>)list;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public JsonResult Add(string cartModel)
        {
            var cart = new JavaScriptSerializer().Deserialize<List<Cart_item>>(cartModel);
            int id = cart[0].ProductID;
            var sessionCart = (List<Cart_item>)Session[SessionCart];//lấy danh sách các sản phẩm trong giỏ hàng hiện có

            if (sessionCart != null)// đã có sản phầm ở giỏ hàng
            {
                var list = (List<Cart_item>)sessionCart;
                if (list.Exists(x => x.ProductID == cart[0].ProductID)) // sản phầm thêm là sản phẩm đã có ở giỏ
                {
                    var quantity1 = 0;
                    int priceTotal = 0;

                    foreach (var item in list)
                    {
                        if (item.ProductID == cart[0].ProductID)
                        {
                            item.Quantity += cart[0].Quantity;
                            quantity1 = item.Quantity;
                            if (Session["id"] != null)// đã đăng nhập
                            {
                                var iCart = ctx.Carts.SingleOrDefault(m => m.ProductID == id);
                                if (iCart != null)  // tồn tại sp ở giỏ => cập nhật
                                {
                                    iCart.ProductID = item.ProductID;
                                    iCart.Quantity = item.Quantity;
                                    iCart.CustomerID = (int)Session["id"];
                                    ctx.SaveChanges();
                                }
                                else
                                {

                                }
                            }
                        }

                    }
                    if (sessionCart != null)    // đã có sản phầm ở giỏ hàng
                    {
                        list = (List<Cart_item>)sessionCart;
                        foreach (var item1 in list)
                        {

                            int temp = ((int)item1.Price) * ((int)item1.Quantity);
                            priceTotal += temp;

                        }
                    }
                    Message.set_flash("Thêm vào giỏ hàng thành công", "success");
                    return Json(new
                    {
                        status = true,
                        Count = list.Count(),
                        quantity = quantity1,
                        productid = cart[0].ProductID,
                        subtotal = priceTotal.ToString("N0"),
                        method = "exist"
                    });
                }
                else // sản phầm thêm là sản phẩm chưa có ở giỏ
                {
                    var tmp = new Cart_item();
                    var product = ctx.Products.SingleOrDefault(m => m.ProductID == id);
                    tmp.ProductID = cart[0].ProductID;
                    tmp.product = product;
                    tmp.Price = (int)product.PriceNew;
                    tmp.Quantity = cart[0].Quantity;
                    list.Add(tmp);
                    Session[SessionCart] = list;
                    if (Session["id"] != null)
                    {
                        var icart = new Cart    // thêm mới sp vào giỏ
                        {
                            ProductID = tmp.ProductID,
                            Quantity = tmp.Quantity,
                            CustomerID = (int)Session["id"],
                        };
                        ctx.Carts.Add(icart);
                        ctx.SaveChanges();
                    }
                    int priceTotal = 0;
                    if (sessionCart != null)
                    {
                        list = (List<Cart_item>)sessionCart;
                        foreach (var item1 in list)
                        {
                            int temp = ((int)item1.Price) * ((int)item1.Quantity);
                            priceTotal += temp;
                        }
                    }
                    Message.set_flash("Thêm vào giỏ hàng thành công", "success");
                    return Json(new
                    {
                        status = true,
                        Count = list.Count(),
                        productid = tmp.ProductID,
                        image = tmp.product.Image,
                        name = tmp.product.ProductName,
                        quantity = tmp.Quantity,
                        price = ((int)tmp.product.PriceNew).ToString("N0"),
                        subtotal = priceTotal.ToString("N0"),
                        method = "add"
                    });
                }
            }
            else // chưa có sản phầm ở giỏ hàng
            {
                var tmp = new Cart_item();
                var product = ctx.Products.SingleOrDefault(m => m.ProductID == id);
                tmp.product = product;
                tmp.ProductID = cart[0].ProductID;
                tmp.Quantity = cart[0].Quantity;
                tmp.Price = (int)product.PriceNew;
                var list = new List<Cart_item>();
                list.Add(tmp);
                Session[SessionCart] = list;
                if (Session["id"] != null)
                {
                    var icart = new Cart    // thêm mới
                    {
                        ProductID = tmp.ProductID,
                        Quantity = tmp.Quantity,
                        CustomerID = (int)Session["id"],
                    };
                    ctx.Carts.Add(icart);
                    ctx.SaveChanges();
                }
                Message.set_flash("Thêm vào giỏ hàng thành công", "success");
                return Json(new
                {
                    status = true,
                    Count = list.Count(),
                    productid = tmp.ProductID,
                    image = tmp.product.Image,
                    name = tmp.product.ProductName,
                    quantity = tmp.Quantity,
                    price = ((int)tmp.product.PriceNew).ToString("N0"),
                    subtotal = ((int)tmp.product.PriceNew).ToString("N0"),
                    method = "add"
                });
            }
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<Cart_item>)Session[SessionCart];//lấy danh sách các sản phẩm trong giỏ hàng hiện có
            sessionCart.RemoveAll(x => x.ProductID == id);
            if (Session["id"] != null)
            {
                int idcustomer = (int)Session["id"];
                var cart = ctx.Carts.SingleOrDefault(m => m.ProductID == id && m.Customer.CustomerID == idcustomer);
                ctx.Carts.Remove(cart);
                ctx.SaveChanges();
            }
            Session[SessionCart] = sessionCart;
            var list = (List<Cart_item>)sessionCart;
            int priceTotal = 0;
            foreach (var item1 in list)
            {
                int temp = ((int)item1.Price) * ((int)item1.Quantity);
                priceTotal += temp;
            }
            Message.set_flash("Xóa sản phẩm giỏ hàng thành công", "success");
            return Json(new
            {
                status = true,
                productid = id,
                subtotal = priceTotal.ToString("N0"),
                Count = list.Count()
            });
        }

        public JsonResult Update(int id, int quantity)
        {
            var sessionCart = (List<Cart_item>)Session[SessionCart];//lấy danh sách các sản phẩm trong giỏ hàng hiện có
            int tempPrice = 0;
            if (sessionCart.Exists(x => x.ProductID == id))
            {
                foreach (var item in sessionCart)
                {
                    if (item.ProductID == id)
                    {
                        tempPrice = item.Price;
                        item.Quantity = quantity;
                        if (Session["id"] != null)
                        {   int idcustomer = (int)Session["id"];
                            var cart = ctx.Carts.SingleOrDefault(m => m.ProductID == id && m.Customer.CustomerID == idcustomer);
                            cart.Quantity = item.Quantity;
                            ctx.SaveChanges();
                        }
                    }
                }
            }

            Session[SessionCart] = sessionCart;
            var list = (List<Cart_item>)sessionCart;
            int priceTotal = 0;
            foreach (var item1 in list)
            {
                int temp = ((int)item1.Price) * ((int)item1.Quantity);
                priceTotal += temp;
            }
            Message.set_flash("Cập nhật sản phẩm giỏ hàng thành công", "success");
            return Json(new
            {
                status = true,
                productid = id,
                quantity = quantity,
                tempprice = (tempPrice * quantity).ToString("N0"),
                subtotal = priceTotal.ToString("N0"),
                Count = list.Count()
            });
        }
    }
}