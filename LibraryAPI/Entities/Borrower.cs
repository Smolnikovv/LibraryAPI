namespace LibraryAPI.Entities
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? FirstBookId { get; set; }
        public int? SecondBookId { get; set; }
        public int? ThirdBookId { get; set; }
        public int? FourthBookId { get; set; }
        public int? FifthBookId { get; set; }
        public virtual Book? FirtBook { get; set; }
        public virtual Book? SecondBook { get; set; }
        public virtual Book? ThirdBook { get; set; }
        public virtual Book? FourthBook { get; set; }
        public virtual Book? FifthBok { get; set; }
    }
}
