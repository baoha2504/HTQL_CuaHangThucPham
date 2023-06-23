using CuaHangThucPham_Desktop.Models;
using DevExpress.Utils.About;
using DevExpress.Utils.Gesture;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class usrLapDonHang : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public List<ThucPham> thucPhams = new List<ThucPham>();
        public List<ThucPhamAdded> thucPhamAddeds = new List<ThucPhamAdded>();
        public int sosanpham;
        public int tongtien;
        public usrLapDonHang()
        {
            InitializeComponent();
        }
        private async void usrLapDonHang_Load(object sender, EventArgs e)
        {
            var products = await webApiService.GetAllProduct();
            for (int i = 0; i < products.Count; i++)
            {
                ThucPham thucPham = new ThucPham(this);
                thucPham.set(products[i].ProductID, products[i].Image, products[i].ProductName, (int)products[i].PriceNew);
                flowLayoutPanel.Controls.Add(thucPham);
                thucPhams.Add(thucPham);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            for (int i = thucPhams.Count - 1; i >= 0; i--)
            {
                if (thucPhams[i].GetProductName().Contains(txtNoiDung.Text) && txtNoiDung.Text != string.Empty)
                {
                    flowLayoutPanel.Controls.Add(thucPhams[i]);
                }
                else if(txtNoiDung.Text == string.Empty)
                {
                    flowLayoutPanel.Controls.Add(thucPhams[i]);
                }
            }
        }

        public void xyly()
        {
            sosanpham = 0;
            tongtien = 0;
            foreach (ThucPhamAdded control in flowLayoutPanelLapDonHang.Controls) // for trong flowlayerpanel
            {
                sosanpham += control.soluong;
                tongtien += control.tong;
            }
            txtSoSanPham.Text = sosanpham.ToString();
            txtTongTien.Text = string.Format("{0:#,##0}", tongtien);
        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (thucPhamAddeds.Count != 0)
            {
                xyly();
                List<BillDetail> billDetails = new List<BillDetail>();
                //List<Inventory> inventories = new List<Inventory>();

                //tạo Bill với BillStatus = 0 (Bán hàng)
                Bill bill = new Bill();
                bill.OrderDate = DateTime.Now;
                if (frmLogin.id == 0)
                {
                    bill.CustomerID = 1;
                }
                else
                {
                    bill.CustomerID = frmLogin.id;
                }
                bill.CustomerID = 1; //////////////////////////sẽ sửa

                bill.Total = tongtien;
                bill.BillStatus = 0;
                var bl = await webApiService.CreateBill(bill);

                //tạo BillDetail
                foreach (var item in thucPhamAddeds)
                {
                    BillDetail bdt = new BillDetail();
                    bdt.Quantity = item.soluong;
                    bdt.Price = item.gia;
                    bdt.BillID = bl.BillID;
                    bdt.ProductID = item.id;
                    billDetails.Add(bdt);
                }
                
                for (int i = 0; i < billDetails.Count; i++)
                {
                    billDetails[i].BillID = bl.BillID;
                    var bldt = await webApiService.CreateBillDetail(billDetails[i]);
                    //var ivt = await webApiService.CreateInventory(inventories[i]);
                }

                MessageBox.Show($"Lập đơn hàng #{bl.BillID} thành công", "Thông báo", MessageBoxButtons.OK);

                // tạo báo cáo
                List<report> reports = new List<report>();
                for (int i = 0; i < billDetails.Count; i++)
                {
                    report rp = new report();
                    rp.BillId = bl.BillID;
                    rp.Total = bill.Total;
                    rp.OrderDate = bill.OrderDate;
                    var cus = await webApiService.GetAccountById((int)bill.CustomerID);
                    rp.NameStaff = cus.FirstName + " " + cus.LastName;
                    rp.Quantity = billDetails[i].Quantity;
                    rp.Price = billDetails[i].Price;
                    var prd = await webApiService.GetProductById((int)billDetails[i].ProductID);
                    rp.ProductName = prd.ProductName;
                    reports.Add(rp);
                }
                reportHoaDonBanHang reportHoaDonBanHang = new reportHoaDonBanHang();
                reportHoaDonBanHang.DataSource = reports;
                reportHoaDonBanHang.ShowPreviewDialog();

            } else
            {
                MessageBox.Show("Kiểm tra lại đơn hàng", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void gbThongTinChiTiet_Enter(object sender, EventArgs e)
        {
            xyly();
        }
    }
}
