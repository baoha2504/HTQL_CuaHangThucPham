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
            var bill = await webApiService.GetAllProduct();
            for(int i = 0; i < bill.Count; i++)
            {
                ThucPham thucPham = new ThucPham();
                thucPham.set(bill[i].Image, bill[i].ProductName, (int)bill[i].PriceNew);
                flowLayoutPanel.Controls.Add(thucPham);
                thucPhams.Add(thucPham);
            }
        }
    }
}
