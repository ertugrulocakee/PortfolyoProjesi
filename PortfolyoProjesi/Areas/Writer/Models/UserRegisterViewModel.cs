using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {

        [Required]
        [MaxLength(30, ErrorMessage = "Ad en fazla 30 karaktere sahip olmalıdır!")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Soyad en fazla 20 karaktere sahip olmalıdır!")]
        public string SurName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karaktere sahip olmalıdır!")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Parola en fazla 30 karaktere sahip olmalıdır!")]
        public string Password { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Parola en fazla 30 karaktere sahip olmalıdır!")]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmelidir!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresi girin!")]
        [MaxLength(30, ErrorMessage = "E-posta en fazla 30 karaktere sahip olmalıdır!")]
        public string Mail { get; set; }

        
        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "Lütfen bir resim seçin!")]
        public IFormFile Picture { get; set; }



    }
}
