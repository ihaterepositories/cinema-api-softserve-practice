using Cinema.Data.Validators;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.AuthDTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        [PasswordValidator(ErrorMessage ="Password must contain at least 1 digit,1 Upper Case and 1 Lower Case Letter")]
        public string Password { get; set; }
    }
}
