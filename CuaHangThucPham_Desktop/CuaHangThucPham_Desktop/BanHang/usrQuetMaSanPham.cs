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
    public partial class usrQuetMaSanPham : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public usrQuetMaSanPham()
        {
            InitializeComponent();
        }

        private async void usrQuetMaSanPham_Load(object sender, EventArgs e)
        {
            var bill = await webApiService.GetAllProduct();
            List<ThucPham> thucPhams = new List<ThucPham>();
            for (int i = 0; i < bill.Count; i++)
            {
                ThucPham thucPham = new ThucPham();
                thucPham.set(bill[i].Image, bill[i].ProductName, (int)bill[i].PriceNew);
                flowLayoutPanel.Controls.Add(thucPham);
                thucPhams.Add(thucPham);
            }
        }
    }
}
