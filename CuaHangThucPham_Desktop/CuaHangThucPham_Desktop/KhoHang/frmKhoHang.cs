using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.KhoHang
{
    public partial class frmKhoHang : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmKhoHang()
        {
            InitializeComponent();
        }

        usrDoiMatKhau usrDoiMatKhau;
        usrHangHetHan usrHangHetHan;
        usrKhoHang usrKhoHang;
        usrLichSuNhapHang usrLichSuNhapHang;
        usrNhapHang usrNhapHang;
        usrTrangChu usrTrangChu;

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if (usrTrangChu == null)
            {
                usrTrangChu usrTrangChu = new usrTrangChu();
                usrTrangChu.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrTrangChu);
                usrTrangChu.BringToFront();
            }
            else
            {
                usrTrangChu.BringToFront();
            }
            lblTieuDe.Caption = "Trang chủ";
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            if (usrKhoHang == null)
            {
                usrKhoHang usrKhoHang = new usrKhoHang();
                usrKhoHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrKhoHang);
                usrKhoHang.BringToFront();
            }
            else
            {
                usrKhoHang.BringToFront();
            }
            lblTieuDe.Caption = "Kho hàng";
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (usrNhapHang == null)
            {
                usrNhapHang usrNhapHang = new usrNhapHang();
                usrNhapHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrNhapHang);
                usrNhapHang.BringToFront();
            }
            else
            {
                usrNhapHang.BringToFront();
            }
            lblTieuDe.Caption = "Nhập hàng";
        }

        private void btnHangHetHan_Click(object sender, EventArgs e)
        {
            if (usrHangHetHan == null)
            {
                usrHangHetHan usrHangHetHan = new usrHangHetHan();
                usrHangHetHan.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrHangHetHan);
                usrHangHetHan.BringToFront();
            }
            else
            {
                usrHangHetHan.BringToFront();
            }
            lblTieuDe.Caption = "Hàng hết hạn";
        }

        private void btnLichSuNhapHang_Click(object sender, EventArgs e)
        {
            if (usrLichSuNhapHang == null)
            {
                usrLichSuNhapHang usrLichSuNhapHang = new usrLichSuNhapHang();
                usrLichSuNhapHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrLichSuNhapHang);
                usrLichSuNhapHang.BringToFront();
            }
            else
            {
                usrLichSuNhapHang.BringToFront();
            }
            lblTieuDe.Caption = "Lịch sử nhập hàng";
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (usrDoiMatKhau == null)
            {
                usrDoiMatKhau usrDoiMatKhau = new usrDoiMatKhau();
                usrDoiMatKhau.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrDoiMatKhau);
                usrDoiMatKhau.BringToFront();
            }
            else
            {
                usrDoiMatKhau.BringToFront();
            }
            lblTieuDe.Caption = "Đổi mật khẩu";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                this.Hide();
            }
        }
    }
}
