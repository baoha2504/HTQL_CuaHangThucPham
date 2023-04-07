using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GroceryStoreContext _context;

        public ProductController(GroceryStoreContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsProduct = _context.Products.ToList();
            return Ok(dsProduct);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dsProduct = _context.Products.SingleOrDefault(m => m.ProductId == id);
            if (dsProduct != null)
            {
                return Ok(dsProduct);
            } else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}&{SubCategoriesId}")]
        public IActionResult GetByIdOder(int id, int SubCategoriesId)
        {
            var dsProduct = _context.Products.SingleOrDefault(m => m.ProductId == id && m.SubCategoriesId == SubCategoriesId);
            if (dsProduct != null)
            {
                return Ok(dsProduct);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            try
            {
                var prd = new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    PriceOld = product.PriceOld,
                    PriceNew = product.PriceNew,
                };
                _context.Add(prd);
                _context.SaveChanges();
                return Ok(prd);
            }
            catch
            {
                return BadRequest(0);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProductById(int id, Product prd)
        {
            var dsProduct = _context.Products.SingleOrDefault(m => m.ProductId == id);
            if (dsProduct != null)
            {
                dsProduct.SubCategoriesId = prd.SubCategoriesId; 
                dsProduct.ProductName = prd.ProductName;
                dsProduct.PriceOld = prd.PriceOld;
                dsProduct.PriceNew = prd.PriceNew;
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
