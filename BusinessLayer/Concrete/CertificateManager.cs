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
    public class CertificateManager : ICertificateService
    {

        ICertificateDAL _certificateDAL;

        public CertificateManager(ICertificateDAL certificateDAL)
        {
            _certificateDAL = certificateDAL;
        }

        public void TAdd(Certificate t)
        {
            _certificateDAL.Insert(t);  
        }

        public void TDelete(Certificate t)
        {
            _certificateDAL.Delete(t);
        }

        public Certificate TGetByID(int id)
        {
            return _certificateDAL.GetByID(id); 
        }

        public List<Certificate> TGetList()
        {
            return _certificateDAL.GetList();   
        }

        public List<Certificate> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Certificate t)
        {
            _certificateDAL.Update(t);  
        }
    }
}
