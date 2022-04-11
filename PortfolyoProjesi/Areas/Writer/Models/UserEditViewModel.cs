using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        [Required]
        [MaxLength(30,ErrorMessage ="Ad en fazla 30 karaktere sahip olmalıdır!")]
        public string Name { get; set; }


        [Required]
        [MaxLength(20, ErrorMessage = "Soyad en fazla 20 karaktere sahip olmalıdır!")]
        public string SurName { get; set; }

       
        public string PictureURL { get; set; }

        public IFormFile Picture { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karaktere sahip olmalıdır!")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage = "Lütfen e-posta adresi girin!")]
        [MaxLength(30, ErrorMessage = "E-posta en fazla 30 karaktere sahip olmalıdır!")]
        public string UserMail { get; set; }    


     }
 }

