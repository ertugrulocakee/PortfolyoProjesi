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
    public class EducationManager : IEducationService
    {

        IEducationDAL educationDAL;

        public EducationManager(IEducationDAL educationDAL)
        {
            this.educationDAL = educationDAL;
        }

        public void TAdd(Education t)
        {

            educationDAL.Insert(t);

        }

        public void TDelete(Education t)
        {
            educationDAL.Delete(t);
        }

        public Education TGetByID(int id)
        {
            return educationDAL.GetByID(id);
        }

        public List<Education> TGetList()
        {
            return educationDAL.GetList();
        }

        public List<Education> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Education t)
        {
            educationDAL.Update(t);

        }
    }
}
