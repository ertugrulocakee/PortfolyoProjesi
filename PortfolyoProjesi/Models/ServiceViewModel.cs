using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class ServiceViewModel
    {
        [Required(ErrorMessage ="Hizmet/Alan adı boş bırakılamaz!")]
        [MaxLength(25,ErrorMessage ="Hizmet/Alan adı maksimum 25 karakterden oluşmalıdır!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Resim seçilmelidir!")]
        public IFormFile Picture { get; set; }

    }
}
