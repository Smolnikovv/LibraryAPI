using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Genre
{
    public class CreateGenreDto
    {
        [Required]
        public string Description { get; set; }
    }
}
