using Flare.Data.Entities;
using Flare.Service;
using Microsoft.AspNetCore.Mvc;

namespace Flare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IRepository<ReviewModel> _repository;

        public ReviewController(IRepository<ReviewModel> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddReview(ReviewModel model)
        {
            _repository.Add(model);
            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{HttpContext.Request.Path}/{model.Id}", model);
        }
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var Response = _repository.GetAll();
            return Ok(Response);

        }
        //this endpoint might be used to report a fake review or pinpoint to a specific review that requires attention
        [HttpGet("{id}")]
        public IActionResult getReview(Guid id)
        {
            var response = _repository.GetById(id);
            return response != null ? Ok(response) : NotFound(response);
        }
        //this endpoint should be able to provide a list of reviews for a particular listing give the id of the listing
        [HttpGet("listing/{listing_id}")]
        public IActionResult getListingReviews(Guid listing_id)
        {
            var response = _repository.GetReviewsByListing(listing_id);
            return response!=null? Ok(response):NotFound(response);
        }
        [HttpPatch("{id}")]
        public IActionResult EditReview(Guid id,ReviewModel review)
        {
            ReviewModel exReview = _repository.GetById(id);
            if(review != null)
            {
                exReview.Review = string.IsNullOrWhiteSpace(review.Review) ? exReview.Review : review.Review;
                exReview.Rating = string.IsNullOrWhiteSpace(review.Rating.ToString())? exReview.Rating: review.Rating;

                _repository.Update(exReview);
                return Ok(exReview);
            }
            return NotFound($"No such review was found, please check that id {id} exists and try again");
           
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(Guid id)
        {
            ReviewModel review = _repository.GetById(id);
            if (review != null)
            {
                _repository.Delete(id);
                return Ok();
            }
            return NotFound("review not found");
        }
    }
}
