using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserLoginViewModel
    {

        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz!")]
        public string UserName { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        public string Password { get; set; }    

    }
}
