using LibraryAPI.Models.Book;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) 
        { 
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _bookService.GetAll();

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _bookService.GetById(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("title/{title}")]
        public ActionResult GetByTitle([FromRoute] string title)
        {
            var result = _bookService.GetByTitle(title);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("author/{authorId}")]
        public ActionResult GetByAuthorId([FromRoute] int authorId)
        {
            var result = _bookService.GetByAuthorId(authorId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("genre/{genreId}")]
        public ActionResult GetByGenreId([FromRoute] int genreId)
        {
            var result = _bookService.GetByGenreId(genreId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bookService.Delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateBookDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _bookService.Create(dto);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBookDto dto, [FromRoute] int id) 
        {  
            if(!ModelState.IsValid)
            {
                return BadRequest();
            } 

            _bookService.Update(id, dto);
            return Ok();
        }
    }
}
