using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuaHangThucPham_Desktop.Models;

namespace CuaHangThucPham_Desktop.KhoHang
{
    public partial class usrLichSuNhapHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public usrLichSuNhapHang()
        {
            InitializeComponent();
        }

        private async void usrLichSuNhapHang_Load(object sender, EventArgs e)
        {
            var inventory = await webApiService.GetAllInventory();
            dtgv.DataSource = inventory;
        }
    }
}
