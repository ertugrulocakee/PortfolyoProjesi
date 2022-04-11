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
    public class SkillsManager : ISkillsService
    {

        ISkillsDAL _skillsDAL;

        public SkillsManager(ISkillsDAL skillsDAL)
        {
            _skillsDAL = skillsDAL;
        }

        public void TAdd(Skills t)
        {
            _skillsDAL.Insert(t);

        }

        public void TDelete(Skills t)
        {

            _skillsDAL.Delete(t);

        }

        public Skills TGetByID(int id)
        {
            return _skillsDAL.GetByID(id);

        }

        public List<Skills> TGetList()
        {

            return _skillsDAL.GetList();

        }

        public List<Skills> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skills t)
        {

            _skillsDAL.Update(t);

        }
    }
}
