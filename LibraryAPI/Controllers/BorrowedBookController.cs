using LibraryAPI.Models.BorrowedBook;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/borrowedBooks")]
    public class BorrowedBookController : Controller
    {
        private readonly IBorrowedBookService _borrowedBookService;
        public BorrowedBookController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }
        [HttpGet("borrower/{borrowerId}")]
        public ActionResult GetByBorrower([FromRoute] int borrowerId)
        {
            var result = _borrowedBookService.GetByBorrower(borrowerId);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("book/{bookId}")]
        public ActionResult GetByBook([FromRoute] int bookId)
        {
            var result = _borrowedBookService.GetByBookId(bookId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateBorrowedBookDto dto)
        {
            if(ModelState.IsValid)
            {
                return BadRequest();
            }

            _borrowedBookService.Create(dto);
            return Created("Created",null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _borrowedBookService.Delete(id);
            return Ok();
        }
    }
}
