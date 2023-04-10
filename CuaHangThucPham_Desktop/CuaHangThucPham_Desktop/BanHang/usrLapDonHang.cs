using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class usrLapDonHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        List<ThucPham> thucPhams = new List<ThucPham>();
        public usrLapDonHang()
        {
            InitializeComponent();
        }
        private async void usrLapDonHang_Load(object sender, EventArgs e)
        {
            var bill = await webApiService.GetAllProduct();
            for (int i = 0; i < bill.Count; i++)
            {
                ThucPham thucPham = new ThucPham();
                thucPham.set(bill[i].Image, bill[i].ProductName, (int)bill[i].PriceNew);
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
    }
}
