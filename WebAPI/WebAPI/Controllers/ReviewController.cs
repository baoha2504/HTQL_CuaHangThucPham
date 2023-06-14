using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        GroceryStoreContext _context = new GroceryStoreContext();
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            var review = _context.Reviews.SingleOrDefault(m => m.ReviewId == id);
            if (review != null)
            {
                return Ok(review);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            try
            {

                var rv = new Review
                {
                    ReviewId = review.ReviewId,
                    ProductId = review.ProductId,
                    CustomerId = review.CustomerId,
                    NumStar = review.NumStar,
                    Comment = review.Comment,
                    DateAdded = review.DateAdded,
                    Reply = review.Reply,
                };
                _context.Add(rv);
                _context.SaveChanges();
                return Ok(rv);
            }
            catch
            {
                return BadRequest(0);
            }
        }
    }
}
