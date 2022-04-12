using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class CertificateViewModel
    {

        [Required(ErrorMessage = "Sertifika adı boş olamaz!")]
        [MaxLength(60,ErrorMessage ="Sertifika adı maksimum 60 karakterden oluşabilir!")]
        public string CertificateName { get; set; }

        [Required(ErrorMessage ="Sertifika pdf dosyasını yükleyin!")]
        public IFormFile CertificatePdf { get; set; }


    }
}
