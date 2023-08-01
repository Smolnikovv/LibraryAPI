using LibraryAPI.Models.Genre;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/genre")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _genreService.GetAll();

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _genreService.GetById(id);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("description/{description}")]
        public ActionResult GetByDescription([FromRoute] string description)
        {
            var result = _genreService.GetByDescription(description);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateGenreDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _genreService.Create(dto);

            return Created($"api/genre/{id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _genreService.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateGenreDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _genreService.Update(id, dto);
            return Ok();
        }
    }
}
