using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class TestimonialViewModel
    {
        [Required(ErrorMessage ="Referans ad-soyad bilgisi boş bırakılamaz!")]
        [StringLength(50,ErrorMessage ="Referans ad-soyad bilgisi en fazla 50 karakterden oluşabilir!")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Referansın şirketi bilgisi boş bırakılamaz!")]
        [StringLength(50, ErrorMessage = "Referansın şirketi bilgisi en fazla 50 karakterden oluşabilir!")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Referansın yorumu boş bırakılamaz!")]
        [StringLength(180, ErrorMessage = "Referansın yorumu en fazla 180 karakterden oluşabilir!")]
        public string Comment { get; set; }

        [Required(ErrorMessage ="Resim Seçilmelidir!")]
        public IFormFile Image { get; set; }


    }
}
