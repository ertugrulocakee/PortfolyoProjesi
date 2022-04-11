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
    public class FeatureManager : IFeatureService
    {

        IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void TAdd(Feature t)
        {
            _featureDAL.Insert(t);  
        }

        public void TDelete(Feature t)
        {
            _featureDAL.Delete(t);  
        }

        public Feature TGetByID(int id)
        {
            return _featureDAL.GetByID(id);
        }

        public List<Feature> TGetList()
        {
            
            return _featureDAL.GetList();
        }

        public List<Feature> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Feature t)
        {
            _featureDAL.Update(t);

        }
    }
}
