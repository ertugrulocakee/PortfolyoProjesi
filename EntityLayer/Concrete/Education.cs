using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; } 
        
        public string EducationTitle { get; set; } 

        public string EducationDescription { get; set; }      
        
        public string EducationImageUrl { get; set; }

        

    }
}
