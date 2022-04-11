using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogPost
    {

        [Key]
        public int id { get; set; }

        public string WriterName { get; set; }  

        public string Header { get; set; } 

        public string Title { get; set; }   

        public string PostContent { get; set; } 

        public string PostImageUrl { get; set; }    

        public string HeaderImageUrl { get; set; }  

        public DateTime Date { get; set; }  

    }
}
