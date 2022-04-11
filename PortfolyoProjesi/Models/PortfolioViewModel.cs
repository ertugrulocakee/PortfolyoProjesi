using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class PortfolioViewModel
    {

        [Required(ErrorMessage = "Proje adı boş olamaz!")]
        [MaxLength(25, ErrorMessage = "Proje adı maksimum 25 karakterden oluşabilir!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resim seçilmelidir!")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage ="Proje URL boş olamaz!")]
        [MaxLength(40, ErrorMessage = "Proje URL maksimum 40 karakterden oluşabilir!")]
        public string ProjectURL { get; set; }

        [Required(ErrorMessage = "Resim seçilmelidir!")]
        public IFormFile BigImage { get; set; }

        [Required(ErrorMessage = "Resim seçilmelidir!")]
        public IFormFile PlatformImage { get; set; }

        [Required(ErrorMessage = "Proje ücreti boş olamaz!")]
        [MaxLength(12, ErrorMessage = "Proje ücreti maksimum 12 karakterden oluşabilir!")]
        public string Price { get; set; }
       
       

        [Required(ErrorMessage = "Proje ilerleme oranı boş olamaz!")]
        [Range(1, 100, ErrorMessage = "Proje ilerleme oranı 1 ile 100 arasında olabilir!")]
        public int Value { get; set; }

    }
}
