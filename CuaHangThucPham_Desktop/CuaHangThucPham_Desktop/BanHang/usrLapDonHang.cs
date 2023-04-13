using CuaHangThucPham_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class usrLapDonHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public List<ThucPham> thucPhams = new List<ThucPham>();
        public List<ThucPhamAdded> thucPhamAddeds = new List<ThucPhamAdded>();
        public int sosanpham;
        public int tongtien;
        public usrLapDonHang()
        {
            InitializeComponent();
        }
        private async void usrLapDonHang_Load(object sender, EventArgs e)
        {
            var products = await webApiService.GetAllProduct();
            for (int i = 0; i < products.Count; i++)
            {
                ThucPham thucPham = new ThucPham(this);
                thucPham.set(products[i].ProductID, products[i].Image, products[i].ProductName, (int)products[i].PriceNew);
                flowLayoutPanel.Controls.Add(thucPham);
                thucPhams.Add(thucPham);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            for (int i = thucPhams.Count - 1; i >= 0; i--)
            {
                if (thucPhams[i].GetProductName().Contains(txtNoiDung.Text) && txtNoiDung.Text != string.Empty)
                {
                    flowLayoutPanel.Controls.Add(thucPhams[i]);
                }
                else if(txtNoiDung.Text == string.Empty)
                {
                    flowLayoutPanel.Controls.Add(thucPhams[i]);
                }
            }
        }

        public void xyly()
        {
            sosanpham = 0;
            tongtien = 0;
            foreach (ThucPhamAdded control in flowLayoutPanelLapDonHang.Controls) // for trong flowlayerpanel
            {
                sosanpham += control.soluong;
                tongtien += control.tong;
            }
            txtSoSanPham.Text = sosanpham.ToString();
            txtTongTien.Text = string.Format("{0:#,##0}", tongtien);
        }
    }
}
