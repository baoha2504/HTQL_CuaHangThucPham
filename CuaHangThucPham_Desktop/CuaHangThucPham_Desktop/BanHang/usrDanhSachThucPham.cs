using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class usrDanhSachThucPham : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        List<ThucPham> thucPhams = new List<ThucPham>();

        public usrDanhSachThucPham()
        {
            InitializeComponent();
        }

        private async void usrDanhSachThucPham_Load(object sender, EventArgs e)
        {
            var products = await webApiService.GetAllProduct();
            List<ThucPham> thucPhams = new List<ThucPham>();
            for (int i = 0; i < products.Count; i++)
            {
                ThucPham thucPham = new ThucPham();
                thucPham.set(products[i].ProductID, products[i].Image, products[i].ProductName, (int)products[i].PriceNew);
                flowLayoutPanel.Controls.Add(thucPham);
                thucPhams.Add(thucPham);
            }
        }
    }
}
