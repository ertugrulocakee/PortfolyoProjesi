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
    public class ExperienceManager : IExperienceService
    {

        IExperienceDAL _experienceDAL;

        public ExperienceManager(IExperienceDAL experienceDAL)
        {
            _experienceDAL = experienceDAL;
        }

        public void TAdd(Experience t)
        {
            _experienceDAL.Insert(t);
        }

        public void TDelete(Experience t)
        {
             _experienceDAL.Delete(t);
        }

        public Experience TGetByID(int id)
        {
             return _experienceDAL.GetByID(id);
        }

        public List<Experience> TGetList()
        {
            return _experienceDAL.GetList();  
            
        }

        public List<Experience> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience t)
        {

            _experienceDAL.Update(t);

        }
    }
}
