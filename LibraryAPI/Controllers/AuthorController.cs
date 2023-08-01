using LibraryAPI.Models.Author;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _authorService.GetAll();

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _authorService.GetById(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            var result = _authorService.GetByName(name);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("surname/{surname}")]
        public ActionResult GetBySurname([FromRoute] string surname)
        {
            var result = _authorService.GetBySurname(surname);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _authorService.Create(dto);
            return Created($"api/author/{id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateAuthorDto dto, [FromRoute] int id)
        {
            if(ModelState.IsValid)
            {
                return BadRequest();
            }

            _authorService.Update(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _authorService.Delete(id);
            return Ok();
        }
    }
}
