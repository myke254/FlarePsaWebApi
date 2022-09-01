using Flare.Data.Entities;
using Flare.Service;
using Microsoft.AspNetCore.Mvc;

namespace Flare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<CategoryModel> _repository;

        public CategoryController(IRepository<CategoryModel> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
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
        [HttpPatch("{id}")]
        public IActionResult Update(CategoryModel model, Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.Category = string.IsNullOrEmpty(model.Category) ? result.Category : model.Category;
                result.Requirements = string.IsNullOrEmpty(model.Requirements) ? result.Requirements : model.Requirements;
                result.Image = string.IsNullOrEmpty(model.Image) ? result.Image : model.Image;

                _repository.Update(result);
                return Ok(result);

            }
            return NotFound($"The id {id} wasn't found ");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_repository.GetById(id) != null)
            {
                _repository.Delete(id);
                return Ok("Deleted");

            }
            return NotFound($"The id {id} wasn't found ");

        }
    }
}
