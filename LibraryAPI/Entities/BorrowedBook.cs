using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Entities
{
    public class BorrowedBook
    {
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Borrower Borrower { get; set; }
    }
}
