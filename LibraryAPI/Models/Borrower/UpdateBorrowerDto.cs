namespace LibraryAPI.Models.Borrower
{
    public class UpdateBorrowerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
