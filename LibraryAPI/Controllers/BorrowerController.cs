using LibraryAPI.Models.Borrower;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/borrower")]
    public class BorrowerController : Controller
    {
        private readonly IBorrowerService _borrowerService;
        public BorrowerController(IBorrowerService borrowerService)
        {
            _borrowerService = borrowerService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _borrowerService.GetAll();

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _borrowerService.GetById(id);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            var result = _borrowerService.GetByName(name);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("surname/{surname}")]
        public ActionResult GetBySurname([FromRoute] string surname)
        {
            var result = _borrowerService.GetBySurname(surname);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateBorrowerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _borrowerService.Create(dto);
            return Created($"api/borrower/{id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBorrowerDto dto, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            _borrowerService.Update(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _borrowerService.Delete(id);
            return Ok();
        }
    }
}
