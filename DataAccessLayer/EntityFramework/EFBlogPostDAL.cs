using EntityLayer.Concrete;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogPostDAL : GenericRepository<BlogPost>, IBlogPostDAL
    {

    }
}
