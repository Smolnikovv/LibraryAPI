namespace LibraryAPI.Models.BorrowedBook
{
    public class UpdateBorrowedBookDto
    {
        public int? BookId { get; set; }
        public int? BorrowerId { get; set; }
    }
}
