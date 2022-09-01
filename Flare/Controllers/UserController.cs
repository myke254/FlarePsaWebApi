using Flare.Data.Entities;
using Flare.Service;
using Microsoft.AspNetCore.Mvc;

namespace Flare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IRepository<UserModel> _repository;

        public UserController(IRepository<UserModel> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddUser(UserModel model)
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
        public IActionResult Update(UserModel model, Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.Name = string.IsNullOrEmpty(model.Name) ? result.Name : model.Name;
                
                result.Picture = string.IsNullOrEmpty(model.Picture) ? result.Picture : model.Picture;
               
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
