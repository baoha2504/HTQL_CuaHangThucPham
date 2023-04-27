using CuaHangThucPham_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using DevExpress.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        string decoded = "";
        private Timer timer;
        public usrQuetMaSanPham()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 2000;

            // Thiết lập sự kiện để thực hiện hàm MyFunction
            timer.Tick += new EventHandler(MyFunction);

            // Bắt đầu timer
            timer.Start();
        }

        private void MyFunction(object sender, EventArgs e)
        {
            decoded = "";
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
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_Newframe);
            FinalFrame.Start();
        }

        private void FinalFrame_Newframe(object sender, NewFrameEventArgs eventArgs)
        {
            var newWidth = 500; // kích thước mới của hình ảnh
            var newHeight = 500;
            var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
            {
                //graphics.DrawImage((Bitmap)eventArgs.Frame.Clone(), 0, 0, 150, 147);
                graphics.DrawImage((Bitmap)eventArgs.Frame.Clone(), 0, 0, 217, 147);
            }


            pictureBox1.Image = newImage;
        }

        private void QuetMa()
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

        private void btnQuet_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void txtNoiDungQuet_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungQuet.Text != "")
            {
                SoundPlayer player = new SoundPlayer(@"D:\HTQL_CuaHangThucPham\CuaHangThucPham_Desktop\CuaHangThucPham_Desktop\Resources\pip.wav");
                player.Play();
                QuetMa();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);

            try
            {
                if (result != null)
                {
                    if (txtNoiDungQuet.Text == "" || txtNoiDungQuet.Text == string.Empty)
                    {
                        decoded = result.ToString().Trim();
                        txtNoiDungQuet.Text = decoded;
                    }
                }
                else
                {
                    txtNoiDungQuet.Text = decoded;
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}
