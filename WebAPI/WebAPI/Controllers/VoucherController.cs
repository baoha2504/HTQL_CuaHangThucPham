using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet]
        public IActionResult GetAllVouchers()
        {
            var vouchers = _context.Vouchers.ToList();
            return Ok(vouchers);
        }

        [HttpGet("{id}")]
        public IActionResult GetVoucherById(int id)
        {
            var voucher = _context.Vouchers.SingleOrDefault(m => m.VoucherId == id);
            if (voucher != null)
            {
                return Ok(voucher);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateVouchers(Voucher voucher)
        {
            try
            {
                var vc = new Voucher
                {
                    VoucherId = voucher.VoucherId,
                    VoucherCode = voucher.VoucherCode,
                    CustomerId = voucher.CustomerId,
                    SalePercent = voucher.SalePercent,
                    MaximumDis = voucher.MaximumDis,
                    MiximunVal = voucher.MiximunVal,
                    Expiry = voucher.Expiry,
                };
                _context.Add(vc);
                _context.SaveChanges();
                return Ok(vc);
            }
            catch
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{id}&{VoucherCode}")]
        public IActionResult UpdateVoucherById(int id, string VoucherCode,  Voucher voucher)
        {
            var dsVoucher = _context.Vouchers.Where(m => m.VoucherId == id && m.VoucherCode == VoucherCode).ToList();
            if (dsVoucher != null)
            {
                dsVoucher[0].VoucherCode = voucher.VoucherCode;
                dsVoucher[0].CustomerId = voucher.CustomerId;
                dsVoucher[0].SalePercent = voucher.SalePercent;
                dsVoucher[0].MaximumDis = voucher.MaximumDis;
                dsVoucher[0].MiximunVal = voucher.MiximunVal;
                dsVoucher[0].Expiry = voucher.Expiry;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
