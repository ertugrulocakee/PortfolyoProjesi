using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class BlogPostViewModel
    {


        [Required(ErrorMessage = "Paylaşım Başlığı boş olamaz!")]
        [MaxLength(30, ErrorMessage = "Paylaşım Başlığı maksimum 30 karakterden oluşabilir!")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Paylaşım Konusu boş olamaz!")]
        [MaxLength(30, ErrorMessage = "Paylaşım Konusu maksimum 30 karakterden oluşabilir!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Paylaşım İçeriği boş olamaz!")]
        [MaxLength(1200, ErrorMessage = "Paylaşım İçeriği maksimum 1200 karakterden oluşabilir!")]
        public string PostContent { get; set; }

        [Required(ErrorMessage ="Resim Seçilmelidir!")]
        public IFormFile Image { get; set; }






    }
}
