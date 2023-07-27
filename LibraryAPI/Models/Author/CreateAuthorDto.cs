using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Author
{
    public class CreateAuthorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
