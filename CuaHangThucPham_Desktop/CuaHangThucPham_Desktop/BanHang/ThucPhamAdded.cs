using System;
using System.Drawing;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.BanHang
{
    public partial class ThucPhamAdded : UserControl
    {
        public ThucPhamAdded()
        {
            InitializeComponent();
        }
        public int id { get; set; }
        public int gia { get; set; }
        public int tong { get; set; }
        public int soluong { get; set; }
        public void set(int Id, string Picture, string Productname, int Price, int Quantity)
        {
            picture.BackgroundImage = Image.FromFile(@"D:\HTQL_CuaHangThucPham\CuaHangThucPham\CuaHangThucPham\Public\image\product\" + Picture);
            productname.Text = Productname;
            price.Text = string.Format("{0:#,##0}", Price) + "đ";
            quantity.Text = Quantity.ToString();
            total.Text = (Int32.Parse(quantity.Text) * Price).ToString();
            gia = Price;
            id = Id;
            soluong = Quantity;
            tong = Quantity * Price;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            quantity.Text = (Int32.Parse(quantity.Text) + 1).ToString();
            soluong = Int32.Parse(quantity.Text);
            total.Text = (Int32.Parse(quantity.Text) * gia).ToString();
            tong = Int32.Parse(quantity.Text) * gia;
            
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (quantity.Text != "0")
            {
                quantity.Text = (Int32.Parse(quantity.Text) - 1).ToString();
                soluong = (Int32.Parse(quantity.Text) - 1);
                total.Text = (Int32.Parse(quantity.Text) * gia).ToString();
                tong = Int32.Parse(quantity.Text) * gia;
            }
            else if (quantity.Text == "0")
            {
            }
        }

        public void tangsoluong()
        {
            quantity.Text = (Int32.Parse(quantity.Text) + 1).ToString();
            soluong = Int32.Parse(quantity.Text);
            total.Text = (Int32.Parse(quantity.Text) * gia).ToString();
            tong = Int32.Parse(quantity.Text) * gia;
        }

        public void annut()
        {
            plus.Hide();
            minus.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
