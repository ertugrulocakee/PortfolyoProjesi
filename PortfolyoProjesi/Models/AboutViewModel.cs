using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class AboutViewModel
    {

        public int Id { get; set; } 

        [Required(ErrorMessage ="Başlık boş olamaz!")]
        [MaxLength(30,ErrorMessage ="Başlık en fazla 30 karakterden oluşabilir!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş olamaz!")]
        [MaxLength(200, ErrorMessage = "Açıklama en fazla 200 karakterden oluşabilir!")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Yaş boş olamaz!")]
        [Range(20,100,ErrorMessage ="Yaş değeri 20 ile 100 arasında olmalıdır!")]
        public string Age { get; set; }

        [Required(ErrorMessage ="E-posta boş olamaz!")]
        [EmailAddress(ErrorMessage ="Bir e-posta girilmelidir!")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Telefon boş olamaz!")]
        [Phone(ErrorMessage ="Bir telefon numarası girilmelidir!")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Adres bilgisi boş olamaz!")]
        [MaxLength(200,ErrorMessage ="Adres bilgisi maksimum 200 karakterden oluşabilir!")]
        public string Address { get; set; }

 
        public IFormFile Image { get; set; }


    }
}
