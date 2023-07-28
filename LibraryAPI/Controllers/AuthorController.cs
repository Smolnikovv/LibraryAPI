using LibraryAPI.Configs;
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

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
