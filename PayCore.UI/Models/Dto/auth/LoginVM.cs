using System.ComponentModel.DataAnnotations;

namespace PayCore.UI.Models.Dto.auth
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string EMail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
