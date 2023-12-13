using System.ComponentModel.DataAnnotations;

namespace PayCore.UI.Models.Dto
{
    public class AddWriterDto
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required!")]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string ImagePath { get; set; } = "";
    }
}
