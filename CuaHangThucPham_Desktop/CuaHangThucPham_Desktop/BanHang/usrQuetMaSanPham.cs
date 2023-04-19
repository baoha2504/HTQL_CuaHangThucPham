using CuaHangThucPham_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class usrQuetMaSanPham : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        List<ThucPham> thucPhams = new List<ThucPham>();
        List<ThucPhamAdded> thucPhamAddeds = new List<ThucPhamAdded>();
        //int[] dem = new int[200];
        public int sosanpham;
        public int tongtien;
        public string noidungquet = "";
        public usrQuetMaSanPham()
        {
            InitializeComponent();
        }

        private async void usrQuetMaSanPham_Load(object sender, EventArgs e)
        {
            var products = await webApiService.GetAllProduct();
            for (int i = 0; i < products.Count; i++)
            {
                //dem[i] = 0;
                ThucPham thucPham = new ThucPham();
                thucPham.set(products[i].ProductID, products[i].Image, products[i].ProductName, (int)products[i].PriceNew);
                flowLayoutPanel.Controls.Add(thucPham);
                thucPhams.Add(thucPham);
            }
        }

        private void btnQuet_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelDonHangQuet.Controls.Count == 0)
            {// chưa có gì trong giỏ
                for (int i = 0; i < thucPhams.Count; i++)
                {
                    if (thucPhams[i].GetId().ToString() == txtNoiDungQuet.Text)
                    {
                        ThucPhamAdded thucPhamAdded = new ThucPhamAdded();
                        thucPhamAdded.set(thucPhams[i].GetId(), thucPhams[i].GetPicture(), thucPhams[i].GetProductName(), thucPhams[i].GetPrice(), 1);
                        thucPhamAdded.annut();
                        flowLayoutPanelDonHangQuet.Controls.Add(thucPhamAdded);
                        thucPhamAddeds.Add(thucPhamAdded);
                        xyly();
                    }
                }
            }
            else// đã có gì trong giỏ
            {
                int dem = 0;
                foreach (ThucPhamAdded control in flowLayoutPanelDonHangQuet.Controls) // for trong flowlayerpanel
                {
                    if (control.id != Int32.Parse(txtNoiDungQuet.Text)) //không trùng với hàng đã có trong giỏ
                    {
                        dem++;
                        //break;
                    }
                    else
                    {
                        control.tangsoluong();
                        xyly();
                    }
                }
                if (dem == flowLayoutPanelDonHangQuet.Controls.Count)
                {
                    for (int i = 0; i < thucPhams.Count; i++)
                    {
                        if (thucPhams[i].GetId().ToString() == txtNoiDungQuet.Text)
                        {
                            ThucPhamAdded thucPhamAdded = new ThucPhamAdded();
                            thucPhamAdded.set(thucPhams[i].GetId(), thucPhams[i].GetPicture(), thucPhams[i].GetProductName(), thucPhams[i].GetPrice(), 1);
                            thucPhamAdded.annut();
                            //flowLayoutPanelDonHangQuet.Controls.Remove(control);
                            flowLayoutPanelDonHangQuet.Controls.Add(thucPhamAdded);
                            thucPhamAddeds.Add(thucPhamAdded);
                            xyly();
                        }
                    }
                }
            }
        }

        public void xyly()
        {
            sosanpham = 0;
            tongtien = 0;
            foreach (ThucPhamAdded control in flowLayoutPanelDonHangQuet.Controls) // for trong flowlayerpanel
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
            }
            else
            {
                MessageBox.Show("Kiểm tra lại đơn hàng", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
