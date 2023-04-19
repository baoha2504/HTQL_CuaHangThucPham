using CuaHangThucPham_Desktop.Models;
using System;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.KhoHang
{
    public partial class usrKhoHang : UserControl
    {
        private readonly WebApiService webApiService;
        public usrKhoHang()
        {
            InitializeComponent();
            webApiService = new WebApiService();
        }

        private async void usrKhoHang_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            var inventory = await webApiService.GetAllInventory();
            for (int i = inventory.Count-1; i >= 0; i--)
            {
                if (inventory[i].ExpirationDate <= dt)
                {
                    inventory.Remove(inventory[i]);
                }
            }
            dtgv.DataSource = inventory;
            //dtgv.Columns.Remove("ProductID");
            //dtgv.Columns.Remove("Customer");
            //dtgv.Columns.Remove("Product");
        }
    }
}
