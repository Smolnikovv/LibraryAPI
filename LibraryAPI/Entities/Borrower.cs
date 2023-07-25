namespace LibraryAPI.Entities
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int[] BorrowedBooksIds { get; set; }
        public virtual Book[] Books { get; set; }
    }
}
