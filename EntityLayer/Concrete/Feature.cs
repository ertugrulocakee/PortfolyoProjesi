using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Feature
    {

       [Key]
       public int FeatureID { get; set; }

       [Required(ErrorMessage ="Başlık boş olamaz!")]
       [MaxLength(30,ErrorMessage ="Başlık en fazla 30 karakterden oluşabilir!")]
       public string Header { get; set; }

       [Required(ErrorMessage ="Ad-Soyad boş olamaz!")]
       [MaxLength(50, ErrorMessage = "Başlık en fazla 50 karakterden oluşabilir!")]
       public string Name { get; set; }

       [Required(ErrorMessage ="Pozisyon boş olamaz!")]
       [MaxLength(40,ErrorMessage ="Pozisyon en fazla 40 karakterden oluşabilir!")]
       public string Title { get; set; }


    }
}
