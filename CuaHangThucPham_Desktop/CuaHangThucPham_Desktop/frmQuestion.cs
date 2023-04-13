using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuaHangThucPham_Desktop.BanHang;
using CuaHangThucPham_Desktop.KhoHang;

namespace CuaHangThucPham_Desktop
{
    public partial class frmQuestion : Form
    {
        public frmQuestion()
        {
            InitializeComponent();
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            frmKhoHang frmKhoHang = new frmKhoHang();
            frmKhoHang.lblHoTen.Caption = "ADMIN";
            frmKhoHang.lblThoiGian.Caption = DateTime.Now.ToShortDateString();
            frmKhoHang.Show();
            this.Hide();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frmBanHang = new frmBanHang();
            frmBanHang.lblHoTen.Caption = "ADMIN";
            frmBanHang.lblThoiGian.Caption = DateTime.Now.ToShortDateString();
            frmBanHang.Show();
            this.Hide();
        }
    }
}
