namespace LibraryAPI.Models.Book
{
    public class UpdateBookDto
    {
        public string? Name { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
    }
}
