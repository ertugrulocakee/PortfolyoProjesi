using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class PasswordChangeViewModel
    {

        [Required]
        [MaxLength(30, ErrorMessage = "Parola en fazla 30 karaktere sahip olmalıdır!")]
        public string Password { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Parola en fazla 30 karaktere sahip olmalıdır!")]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmelidir!")]
        public string ConfirmPassword { get; set; }

    }
}
