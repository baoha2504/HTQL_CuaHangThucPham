using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CuaHangThucPham.Models;

namespace CuaHangThucPham
{
    public class WebApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public WebApiService()
        {
            // Thiết lập base URL cho Web API Service
            try
            {
                client.BaseAddress = new Uri("https://localhost:7295");

                // Thiết lập header cho HTTP request
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        //Product
        public async Task<Product> GetProductById(int id)//lấy 1
        {
            var response = await client.GetAsync($"api/Product/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Product>(json);
            return myObject;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var response = await client.GetAsync("api/Product");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Product>>(json);
            return myObject;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var jsonData = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Product", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Product>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var jsonData = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
           // var response = await client.PostAsync("api/Product", content);
            var response = await client.PutAsync($"api/Product/{product.ProductID}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Product>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //Inventory
        public async Task<List<Inventory>> GetAllInventory()
        {
            var response = await client.GetAsync("api/Inventory");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Inventory>>(json);
            return myObject;
        }

        //Bill
        public async Task<List<Bill>> GetAllBill(int billStatus)
        {
            var response = await client.GetAsync($"api/Bill/{billStatus}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Bill>>(json);
            return myObject;
        }

        //BillDetail
        public async Task<List<BillDetail>> GetAllBillDetailByBillId(int billid)
        {
            var response = await client.GetAsync($"api/BillDetail/{billid}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<BillDetail>>(json);
            return myObject;
        }

        //Account
        public async Task<Customer> GetAccountById(int id)//lấy 1
        {
            var response = await client.GetAsync($"api/Account/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Customer>(json);
            return myObject;
        }

        public async Task<Customer> GetAccountByEmail(string email, string pass)//lấy 1
        {
            var response = await client.GetAsync($"api/Account/{email}&{pass}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Customer>(json);
            return myObject;
        }

        public async Task<List<Customer>> GetAllAccount()
        {
            var response = await client.GetAsync("api/Account");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Customer>>(json);
            return myObject;
        }
        
        public async Task<Customer> UpdateAccount(Customer customer)
        {
            var jsonData = JsonConvert.SerializeObject(customer);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/Customer/{customer.CustomerID}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Customer>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //order
        public async Task<Order> GetOrderById(int id)
        {
            var response = await client.GetAsync($"api/Order/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Order>(json);
            return myObject;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var response = await client.GetAsync("api/Order");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Order>>(json);
            return myObject;
        }

        //OrderDetail
        public async Task<List<OrderDetail>> GetOrderDetailById(int id)
        {
            var response = await client.GetAsync($"api/OrderDetail/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
            return myObject;
        }

        //orderStatusHistory
        public async Task<List<OrderStatusHistory>> GetAllOrderStatusHistory()
        {
            var response = await client.GetAsync("api/OrderStatusHistory");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<OrderStatusHistory>>(json);
            return myObject;
        }

        public async Task<List<OrderStatusHistory>> GetOrderStatusHistoryById(int id)
        {
            var response = await client.GetAsync($"api/OrderStatusHistory/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<OrderStatusHistory>>(json);
            return myObject;
        }

        public async Task<OrderStatusHistory> CreateOrderStatusHistory(OrderStatusHistory orderStatusHistory)
        {
            var jsonData = JsonConvert.SerializeObject(orderStatusHistory);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/OrderStatusHistory", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<OrderStatusHistory>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //shipping
        public async Task<Shipping> GetShippingById(int id)//lấy 1
        {
            var response = await client.GetAsync($"api/Shipping/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Shipping>(json);
            return myObject;
        }

        //payment
        public async Task<Payment> GetPaymentById(int id)//lấy 1
        {
            var response = await client.GetAsync($"api/Payment/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Payment>(json);
            return myObject;
        }

        //subCategories
        public async Task<List<SubCategory>> GetAllSubCategory()
        {
            var response = await client.GetAsync($"api/SubCategory"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<SubCategory>>(json);
            return myObject;
        }

        public async Task<SubCategory> GetSubCategoriesById(int id)
        {
            var response = await client.GetAsync($"api/SubCategory/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<SubCategory>(json);
            return myObject;
        }

        //blog
        public async Task<Blog> GetBlogById(int id)
        {
            var response = await client.GetAsync($"api/Blog/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Blog>(json);
            return myObject;
        }

        public async Task<List<Blog>> GetAllBlogById()
        {
            var response = await client.GetAsync($"api/Blog"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Blog>>(json);
            return myObject;
        }

        public async Task<Blog> CreateBlog(Blog blog)
        {
            var jsonData = JsonConvert.SerializeObject(blog);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Blog", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Blog>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            var jsonData = JsonConvert.SerializeObject(blog);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // var response = await client.PostAsync("api/Product", content);
            var response = await client.PutAsync($"api/Blog/{blog.BlogID}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Blog>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //voucher
        public async Task<Voucher> GetVoucherById(int id)
        {
            var response = await client.GetAsync($"api/Voucher/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Voucher>(json);
            return myObject;
        }

        public async Task<List<Voucher>> GetAllVoucher()
        {
            var response = await client.GetAsync("api/Voucher");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Voucher>>(json);
            return myObject;
        }

        public async Task<Voucher> CreateVoucher(Voucher voucher)
        {
            var jsonData = JsonConvert.SerializeObject(voucher);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Voucher", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Voucher>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        public async Task<Voucher> UpdateVoucher(Voucher voucher)
        {
            var jsonData = JsonConvert.SerializeObject(voucher);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/Voucher/{voucher.VoucherID}&{voucher.VoucherCode}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Voucher>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //review
        public async Task<Review> GetReviewById(int id)
        {
            var response = await client.GetAsync($"api/Review/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Review>(json);
            return myObject;
        }

        public async Task<List<Review>> GetAllReview()
        {
            var response = await client.GetAsync("api/Review");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Review>>(json);
            return myObject;
        }

        public async Task<Review> CreateReview(Review review)
        {
            var jsonData = JsonConvert.SerializeObject(review);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Review", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Review>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }
    }
}
