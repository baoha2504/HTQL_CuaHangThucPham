using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CuaHangThucPham_Desktop.Models;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views.Widget;

namespace CuaHangThucPham_Desktop
{
    public class WebApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public WebApiService()
        {
            // Thiết lập base URL cho Web API Service
            try
            {
                client.BaseAddress = new Uri("https://localhost:7295/");

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
        public async Task<Inventory> CreateInventory(Inventory inventory)
        {
            var jsonData = JsonConvert.SerializeObject(inventory);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Inventory", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Inventory>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //Bill
        public async Task<List<Bill>> GetBillByBillStatus(int billStatus)
        {
            var response = await client.GetAsync($"api/Bill/{billStatus}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<List<Bill>>(json);
            return myObject;
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            var jsonData = JsonConvert.SerializeObject(bill);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Bill", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<Bill>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //BillDetail
        public async Task<BillDetail> CreateBillDetail(BillDetail billDetail)
        {
            var jsonData = JsonConvert.SerializeObject(billDetail);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/BillDetail", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<BillDetail>(responseContent);
                return myObject;
            }
            else
            {
                throw new Exception($"Failed to add product to API. Status code: {response.StatusCode}");
            }
        }

        //Account
        public async Task<Customer> GetAccountByEmail(string email, string pass)//lấy 1
        {
            var response = await client.GetAsync($"api/Account/{email}&{pass}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Customer>(json);
            return myObject;
        }

    }
}
