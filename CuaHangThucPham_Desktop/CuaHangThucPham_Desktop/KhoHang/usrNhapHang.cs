using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.KhoHang
{
    public partial class usrNhapHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public usrNhapHang()
        {
            InitializeComponent();
        }

        private async void usrNhapHang_Load(object sender, EventArgs e)
        {
            var products = await webApiService.GetAllProduct();
            dtgv.DataSource = products;
        }
    }
}
