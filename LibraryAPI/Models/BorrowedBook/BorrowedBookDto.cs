using LibraryAPI.Models.Borrower;
using LibraryAPI.Models.Book;
namespace LibraryAPI.Models.BorrowedBook
{
    public class BorrowedBookDto
    {
        public BorrowerDto Borrower { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
