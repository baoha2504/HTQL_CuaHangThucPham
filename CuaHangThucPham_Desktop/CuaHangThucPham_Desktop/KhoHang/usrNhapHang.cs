using CuaHangThucPham_Desktop.Models;
using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.KhoHang
{
    public partial class usrNhapHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        List<BillDetail> billDetails = new List<BillDetail>();
        
        string productid = "";
        public usrNhapHang()
        {
            InitializeComponent();
        }

        private async void usrNhapHang_Load(object sender, EventArgs e)
        {
            var products = await webApiService.GetAllProduct();
            dtgv.DataSource = products;
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtNoiDung.Text != string.Empty)
            {
                var products = await webApiService.GetAllProduct();
                var product = products.FindAll(p => p.ProductName.Contains(txtNoiDung.Text));
                dtgv.DataSource = product;
            }
            else
            {
                var products = await webApiService.GetAllProduct();
                dtgv.DataSource = products;
            }
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView != null && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[2];
                string value = cell.Value.ToString();
                txtTenThucPham.Text = value;
                productid = row.Cells[0].Value.ToString();
            }
            dtpNgayHetHan.Value = DateTime.Now.AddMonths(3);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSoLuongNhap.Text == string.Empty || txtSoLuongNhap.Text == "0" || txtGia.Text == string.Empty || txtGia.Text == "0")
                {
                    MessageBox.Show("Thông tin chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    int soluong = Int32.Parse(txtSoLuongNhap.Text);
                    int gia = Int32.Parse(txtGia.Text);
                    BillDetail bdt = new BillDetail();
                    bdt.Quantity = soluong;
                    bdt.Price = gia;
                    bdt.ProductID = Int32.Parse(productid);
                    billDetails.Add(bdt);

                    dtgvNhap.DataSource = "";
                    dtgvNhap.DataSource = billDetails;
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnNhap_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.OrderDate = DateTime.Now;
            if(frmLogin.id == 0)
            {
                bill.CustomerID = '1';
            }else
            {
                bill.CustomerID = frmLogin.id;
            }
            bill.CustomerID = 1; //////////////sẽ sửa
            int total = 0;
            for(int i = 0; i < billDetails.Count; i++)
            {
                total += (int)(billDetails[i].Quantity * billDetails[i].Price);
            }
            bill.Total = total;

            var bl = await webApiService.CreateBill(bill);
            MessageBox.Show("Thêm bill thành công", "Thông báo", MessageBoxButtons.OK);

            for (int i = 0; i < billDetails.Count; i++)
            {
                billDetails[i].BillID = bl.BillID;
                var bldt = await webApiService.CreateBillDetail(billDetails[i]);
                MessageBox.Show("Thêm billDetails[i] thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
