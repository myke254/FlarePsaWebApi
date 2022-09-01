using Flare.Data.Entities;
using Flare.Service;
using Microsoft.AspNetCore.Mvc;

namespace Flare.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly IRepository<ListingModel> _repository;

        public ListingController(IRepository<ListingModel> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddListing(ListingModel model)
        {
            _repository.Add(model);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + model.Id, model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Not Found");
        }

        [HttpGet("category/{category}")]
        public IActionResult GetListingsByCategory(string category)
        {
            var response = _repository.GetListingByCategory(category);
            return response != null ? Ok(response) : NotFound(response);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(ListingModel model, Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.Name = string.IsNullOrEmpty(model.Name) ? result.Name : model.Name;
                result.Category = string.IsNullOrEmpty(model.Category) ? result.Category : model.Category;
                
                result.Description = string.IsNullOrEmpty(model.Description) ? result.Description : model.Description;
                result.Image = result.Image ?? model.Image;
                result.Coords = result.Coords ?? model.Coords;
                result.Price = string.IsNullOrEmpty(model.Price.ToString()) ? result.Price : model.Price;
                _repository.Update(result);
                return Ok(result);

            }
            return NotFound($"The id {id} cannot be found ");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_repository.GetById(id) != null)
            {
                _repository.Delete(id);
                return Ok("Deleted");

            }
            return NotFound($"The id {id} cannot be found ");

        }
    }
}
