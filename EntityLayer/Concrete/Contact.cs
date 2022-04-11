using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {

        [Key]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Başlık boş olamaz!")]
        [MaxLength(25, ErrorMessage = "Başlık maksimum 25 karakterden oluşabilir!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş olamaz!")]
        [MaxLength(200, ErrorMessage = "Açıklama maksimum 200 karakterden oluşabilir!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "E-posta boş olamaz!")]
        [MaxLength(30, ErrorMessage = "E-posta maksimum 30 karakterden oluşabilir!")]
        [EmailAddress( ErrorMessage = "Lütfen bir e-posta adresi girin!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Telefon boş olamaz!")]
        [MaxLength(20, ErrorMessage = "Telefon maksimum 20 karakterden oluşabilir!")]
        [Phone(ErrorMessage = "Lütfen bir telefon numarası girin!")]
        public string Phone { get; set; }


    }
}
