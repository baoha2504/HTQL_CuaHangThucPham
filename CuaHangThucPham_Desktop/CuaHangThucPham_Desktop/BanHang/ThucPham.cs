using CuaHangThucPham_Desktop.Models;
using DevExpress.XtraExport.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class ThucPham : UserControl
    {
        public ThucPham()
        {
            InitializeComponent();
        }

        public ThucPham(usrLapDonHang usrLapDonHang)
        {
            InitializeComponent();
            this.usrLapDonHang = usrLapDonHang;
        }
        public usrLapDonHang usrLapDonHang;
        public int giaSP { get; set; }
        public int id { get; set; }
        public string anh { get; set; }
        public void set(int Id, string Picture, string Productname, int Price)
        {
            picture.BackgroundImage = Image.FromFile(@"D:\HTQL_CuaHangThucPham\CuaHangThucPham\CuaHangThucPham\Public\image\product\" + Picture);
            productname.Text = "#" + Id.ToString() + " "+ Productname;
            price.Text = string.Format("{0:#,##0}", Price) + "đ";
            giaSP = Price;
            id = Id;
            anh = Picture;
        }
        public int GetId()
        {
            return id;
        }
        public string GetPicture()
        {
            return anh;
        }
        public string GetProductName(){ 
            return productname.Text;   
        }
        public int GetPrice()
        {
            return giaSP;
        }

        private void picture_Click(object sender, EventArgs e)
        {
            ThucPham_Click(sender, e);
        }

        public void ThucPham_Click(object sender, EventArgs e)
        {
            if (usrLapDonHang.flowLayoutPanelLapDonHang.Controls.Count == 0)
            {// chưa có gì trong giỏ
                for (int i = 0; i < usrLapDonHang.thucPhams.Count; i++)
                {
                    if (usrLapDonHang.thucPhams[i].GetId() == id)
                    {
                        ThucPhamAdded thucPhamAdded = new ThucPhamAdded();
                        thucPhamAdded.set(usrLapDonHang.thucPhams[i].GetId(), usrLapDonHang.thucPhams[i].GetPicture(), usrLapDonHang.thucPhams[i].GetProductName(), usrLapDonHang.thucPhams[i].GetPrice(), 1);
                        usrLapDonHang.flowLayoutPanelLapDonHang.Controls.Add(thucPhamAdded);
                        usrLapDonHang.thucPhamAddeds.Add(thucPhamAdded);
                        usrLapDonHang.xyly();
                    }
                }
            }
            else// đã có gì trong giỏ
            {
                int dem = 0;
                foreach (ThucPhamAdded control in usrLapDonHang.flowLayoutPanelLapDonHang.Controls) // for trong flowlayerpanel
                {
                    if (control.id != id) //không trùng với hàng đã có trong giỏ
                    {
                        dem++;
                        //break;
                    }
                    else
                    {
                        control.tangsoluong();
                        usrLapDonHang.xyly();
                    }
                }
                if (dem == usrLapDonHang.flowLayoutPanelLapDonHang.Controls.Count)
                {
                    for (int i = 0; i < usrLapDonHang.thucPhams.Count; i++)
                    {
                        if (usrLapDonHang.thucPhams[i].GetId() == id)
                        {
                            ThucPhamAdded thucPhamAdded = new ThucPhamAdded();
                            thucPhamAdded.set(usrLapDonHang.thucPhams[i].GetId(), usrLapDonHang.thucPhams[i].GetPicture(), usrLapDonHang.thucPhams[i].GetProductName(), usrLapDonHang.thucPhams[i].GetPrice(), 1);
                            usrLapDonHang.flowLayoutPanelLapDonHang.Controls.Add(thucPhamAdded);
                            usrLapDonHang.thucPhamAddeds.Add(thucPhamAdded);
                            usrLapDonHang.xyly();
                        }
                    }
                }
            }
        }
    }
}
