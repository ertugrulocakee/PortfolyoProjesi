using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {

        ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDAL.Insert(t);  
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaDAL.Delete(t);  
        }

        public SocialMedia TGetByID(int id)
        {
           return  _socialMediaDAL.GetByID(id);   

        }

        public List<SocialMedia> TGetList()
        {            
            return _socialMediaDAL.GetList();   
        }

        public List<SocialMedia> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDAL.Update(t);  
        }
    }
}
