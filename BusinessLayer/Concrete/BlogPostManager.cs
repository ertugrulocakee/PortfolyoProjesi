using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogPostManager : IBlogPostService
    {

        IBlogPostDAL _blogPostDAL;

        public BlogPostManager(IBlogPostDAL blogPostDAL)
        {
            _blogPostDAL = blogPostDAL;
        }

        public void TAdd(BlogPost t)
        {
            _blogPostDAL.Insert(t);
        }

        public void TDelete(BlogPost t)
        {
            _blogPostDAL.Delete(t); 
        }

        public BlogPost TGetByID(int id)
        {
            return _blogPostDAL.GetByID(id);
        }

        public List<BlogPost> TGetList()
        {
            return _blogPostDAL.GetList();  
        }

        public List<BlogPost> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(BlogPost t)
        {
            _blogPostDAL.Update(t);
        }
    }
}
