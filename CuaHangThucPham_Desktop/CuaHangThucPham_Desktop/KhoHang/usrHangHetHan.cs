using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangThucPham_Desktop.KhoHang
{
    public partial class usrHangHetHan : UserControl
    {
        private readonly WebApiService webApiService = new WebApiService();
        public usrHangHetHan()
        {
            InitializeComponent();
        }

        private async void usrHangHetHan_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            var inventory = await webApiService.GetAllInventory();
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].ExpirationDate <= dt)
                {
                    inventory.Remove(inventory[i]);
                }
            }
            dtgv.DataSource = inventory;
        }
    }
}
