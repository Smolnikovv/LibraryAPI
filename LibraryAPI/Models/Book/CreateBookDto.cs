using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Book
{
    public class CreateBookDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
