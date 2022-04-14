using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class ExperienceViewModel
    {

        [Required(ErrorMessage ="Deneyim adı boş olamaz!")]
        [MaxLength(20,ErrorMessage ="Deneyim adı maksimum 20 karakterden oluşabilir!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Deneyimin zaman bilgisi boş olamaz!")]
        [MaxLength(20, ErrorMessage = "Deneyimin zaman bilgisi maksimum 20 karakterden oluşabilir!")]
        public string Date { get; set; }

        [Required(ErrorMessage ="Resim seçilmelidir!")]  
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage ="Deneyimin açıklaması boş bırakılamaz!")]
        [MaxLength(200, ErrorMessage ="Deneyimin açıklaması maksimum 200 karakterden oluşabilir!")]
        public string Description { get; set; }

    }
}
