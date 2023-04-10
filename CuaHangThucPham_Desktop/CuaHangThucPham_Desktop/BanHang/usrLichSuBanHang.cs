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
    public partial class usrLichSuBanHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public usrLichSuBanHang()
        {
            InitializeComponent();
        }

        private async void usrLichSuBanHang_Load(object sender, EventArgs e)
        {
            var bill = await webApiService.GetAllBill();
            dtgv.DataSource = bill;
        }
    }
}
