using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Borrower
{
    public class CreateBorrowerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
