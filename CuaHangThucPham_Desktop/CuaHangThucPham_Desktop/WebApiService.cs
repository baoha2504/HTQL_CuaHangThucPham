using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CuaHangThucPham_Desktop.Models;

namespace CuaHangThucPham_Desktop
{
    public class WebApiService
    {
        private readonly HttpClient _httpClient;

        public WebApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7295/api/"); // Đổi địa chỉ của WebAPI của bạn ở đây
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Product> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"Product/{id}"); // Đổi đường dẫn API lấy đối tượng của bạn ở đây
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var myObject = JsonConvert.DeserializeObject<Product>(json);
            return myObject;
        }
    }
}
