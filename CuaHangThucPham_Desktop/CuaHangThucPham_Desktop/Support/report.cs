using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangThucPham_Desktop
{
    public class report
    {
        public int BillId { get; set; }
        public long? Total { get; set; }
        public DateTime? OrderDate { get; set; }
        public string NameStaff { get; set; }
        public int? Quantity { get; set; }
        public long? Price { get; set; }
        public string ProductName { get; set; }
    }
}
