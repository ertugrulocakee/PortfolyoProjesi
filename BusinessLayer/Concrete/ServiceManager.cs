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
    public class ServiceManager : IServiceService
    {

        IServiceDAL _serviceDAL;

        public ServiceManager(IServiceDAL serviceDAL)
        {
            _serviceDAL = serviceDAL;
        }

        public void TAdd(Service t)
        {
            _serviceDAL.Insert(t);  
        }

        public void TDelete(Service t)
        {
            _serviceDAL.Delete(t);  
        }

        public Service TGetByID(int id)
        {
            return _serviceDAL.GetByID(id); 
        }

        public List<Service> TGetList()
        {
            return _serviceDAL.GetList();   
        }

        public List<Service> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Service t)
        {
            _serviceDAL.Update(t);

        }
    }
}
