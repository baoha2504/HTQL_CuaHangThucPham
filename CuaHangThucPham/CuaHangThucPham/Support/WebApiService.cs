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

        //Inventory
        public async Task<List<Inventory>> GetAllInventory()
        {
            var response = await client.GetAsync("api/Inventory");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject< List<Inventory>>(json);
            return myObject;
        }

        //Bill
        public async Task<List<Bill>> GetAllBill()
        {
            var response = await client.GetAsync("api/Bill");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Bill>>(json);
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

        //order
        public async Task<List<Order>> GetAllOrder()
        {
            var response = await client.GetAsync("api/Order");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Order>>(json);
            return myObject;
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

        //orderStatusHistory
        public async Task<List<OrderStatusHistory>> GetOrderStatusHistoryById(int id)//lấy 1
        {
            var response = await client.GetAsync($"api/OrderStatusHistory/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<OrderStatusHistory>>(json);
            return myObject;
        }

    }
}
