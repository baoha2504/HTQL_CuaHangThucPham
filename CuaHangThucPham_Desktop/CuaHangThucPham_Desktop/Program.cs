using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuaHangThucPham_Desktop.BanHang;
using CuaHangThucPham_Desktop.KhoHang;

namespace CuaHangThucPham_Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmBanHang());
            //Application.Run(new frmKhoHang());
        }
    }
}
