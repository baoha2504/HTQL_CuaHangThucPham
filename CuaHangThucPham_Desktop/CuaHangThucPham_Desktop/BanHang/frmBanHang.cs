using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class frmBanHang : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmBanHang()
        {
            InitializeComponent();
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

        usrDanhSachThucPham usrDanhSachThucPham;
        usrDoiMatKhau usrDoiMatKhau;
        usrLapDonHang usrLapDonHang;
        usrLichSuBanHang usrLichSuBanHang;
        usrQuetMaSanPham usrQuetMaSanPham;
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

        private void btnDSThucPham_Click(object sender, EventArgs e)
        {
            if (usrDanhSachThucPham == null)
            {
                usrDanhSachThucPham usrDanhSachThucPham = new usrDanhSachThucPham();
                usrDanhSachThucPham.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrDanhSachThucPham);
                usrDanhSachThucPham.BringToFront();
            }
            else
            {
                usrDanhSachThucPham.BringToFront();
            }
            lblTieuDe.Caption = "Danh sách thực phẩm";
        }

        private void btnLapDonHang_Click(object sender, EventArgs e)
        {
            if (usrLapDonHang == null)
            {
                usrLapDonHang usrLapDonHang = new usrLapDonHang();
                usrLapDonHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrLapDonHang);
                usrLapDonHang.BringToFront();
            }
            else
            {
                usrLapDonHang.BringToFront();
            }
            lblTieuDe.Caption = "Lập đơn hàng";
        }

        private void btnQuetMaSP_Click(object sender, EventArgs e)
        {
            if (usrQuetMaSanPham == null)
            {
                usrQuetMaSanPham usrQuetMaSanPham = new usrQuetMaSanPham();
                usrQuetMaSanPham.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrQuetMaSanPham);
                usrQuetMaSanPham.BringToFront();
            }
            else
            {
                usrQuetMaSanPham.BringToFront();
            }
            lblTieuDe.Caption = "Quét mã sản phẩm";
        }

        private void btnLichSuBanHang_Click(object sender, EventArgs e)
        {
            if (usrLichSuBanHang == null)
            {
                usrLichSuBanHang usrLichSuBanHang = new usrLichSuBanHang();
                usrLichSuBanHang.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(usrLichSuBanHang);
                usrLichSuBanHang.BringToFront();
            }
            else
            {
                usrLichSuBanHang.BringToFront();
            }
            lblTieuDe.Caption = "Lịch sử bán hàng";
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
