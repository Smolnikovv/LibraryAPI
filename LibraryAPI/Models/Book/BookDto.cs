namespace LibraryAPI.Models.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
