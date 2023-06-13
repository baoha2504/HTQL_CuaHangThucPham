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
            }
            else
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
                    SubCategoriesId = product.SubCategoriesId,
                    ProductName = product.ProductName,
                    Summary = product.Summary,
                    Description = product.Description,
                    Image = product.Image,
                    PriceNew = product.PriceNew,
                    PriceOld = product.PriceOld,
                    Brand = product.Brand,
                    Model = product.Model,
                    Suppiler = product.Suppiler,
                    Status = product.Status,
                    DateAdded = product.DateAdded,
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
        public IActionResult UpdateProductById(int id, Product product)
        {
            var dsProduct = _context.Products.SingleOrDefault(m => m.ProductId == id);
            if (dsProduct != null)
            {
                dsProduct.SubCategoriesId = product.SubCategoriesId;
                dsProduct.ProductName = product.ProductName;
                dsProduct.Summary = product.Summary;
                dsProduct.Description = product.Description;
                dsProduct.Image = product.Image;
                dsProduct.PriceNew = product.PriceNew;
                dsProduct.PriceOld = product.PriceOld;
                dsProduct.Brand = product.Brand;
                dsProduct.Model = product.Model;
                dsProduct.Suppiler = product.Suppiler;
                dsProduct.Status = product.Status;
                dsProduct.DateAdded = product.DateAdded;
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
