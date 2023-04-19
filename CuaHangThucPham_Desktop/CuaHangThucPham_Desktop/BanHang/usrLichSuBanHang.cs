using System;
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
            var bill = await webApiService.GetBillByBillStatus(0);
            dtgv.DataSource = bill;
        }
    }
}
