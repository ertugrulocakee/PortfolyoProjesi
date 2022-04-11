using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class EducationViewModel
    {

        [Required(ErrorMessage ="Okul adı boş olamaz!")]
        [MaxLength(35,ErrorMessage ="Okul adı maksimum 35 karakterden oluşabilir!")]
        public string EducationTitle { get; set; }

        [Required(ErrorMessage = "Açıklama boş olamaz!")]
        [MaxLength(150, ErrorMessage = "Açıklama maksimum 150 karakterden oluşabilir!")]
        public string EducationDescription { get; set; }

        [Required(ErrorMessage ="Resim seçilmelidir!")]
        public IFormFile Image { get; set; }


    }
}
