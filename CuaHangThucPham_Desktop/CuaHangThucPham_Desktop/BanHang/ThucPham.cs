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
        int giaSP = 0;
        public void set(string Picture, string Productname, int Price)
        {
            picture.BackgroundImage = Image.FromFile(@"D:\HTQL_CuaHangThucPham\CuaHangThucPham\CuaHangThucPham\Public\image\product\" + Picture);
            productname.Text = Productname;
            price.Text = string.Format("{0:#,##0}", Price) + "đ";
            giaSP = Price;
        }
        public string GetProductName(){ 
            return productname.Text;   
        }
        public int GetPrice()
        {
            return giaSP;
        }
    }
}
