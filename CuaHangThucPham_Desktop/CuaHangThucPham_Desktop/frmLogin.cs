﻿using CuaHangThucPham_Desktop.BanHang;
using CuaHangThucPham_Desktop.KhoHang;
using System;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        Support support = new Support();
        public static string emailNguoiDung = null;
        public static string passNguoiDung = null;
        public static int id = 0;
        private readonly WebApiService webApiService = new WebApiService();

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var admins = await webApiService.GetAccountByEmail(email.Text, support.EncodePassword(pass.Text));
                emailNguoiDung = email.Text;
                passNguoiDung = support.EncodePassword(pass.Text);
                id = admins.CustomerID;
                if (admins != null)
                {
                    if (admins.Access == 1 && admins.Prohibit == 1)
                    {
                        frmQuestion frmQuestion = new frmQuestion();
                        frmQuestion.Show();
                        this.Hide();
                    }
                    else if (admins.Access == 2 && admins.Prohibit == 1)
                    {
                        frmBanHang frmBanHang = new frmBanHang();
                        frmBanHang.lblHoTen.Caption = admins.FirstName + " " + admins.LastName;
                        frmBanHang.lblThoiGian.Caption = DateTime.Now.ToShortDateString();
                        frmBanHang.Show();
                        this.Hide();
                    }
                    else if (admins.Access == 3 && admins.Prohibit == 1)
                    {
                        frmKhoHang frmKhoHang = new frmKhoHang();
                        frmKhoHang.Show();
                        frmKhoHang.lblHoTen.Caption = admins.FirstName + " " + admins.LastName;
                        frmKhoHang.lblThoiGian.Caption = DateTime.Now.ToShortDateString();
                        this.Hide();
                    }
                    else if (admins.Access == 4 && admins.Prohibit == 1) {
                        MessageBox.Show("Tài khoản không có quyền truy cập vào hệ thống này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(admins.Prohibit != 1) {
                        MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ với admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
