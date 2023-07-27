using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.BorrowedBook
{
    public class CreateBorrowedBookDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int BorrowerId { get; set; }
    }
}
