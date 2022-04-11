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
    public class WriterManager : IWriterService
    {

        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void TAdd(WriterUser t)
        {
             _writerDAL.Insert(t);  
        }

        public void TDelete(WriterUser t)
        {
            _writerDAL.Delete(t);   
        }

        public WriterUser TGetByID(int id)
        {
            return _writerDAL.GetByID(id);  
        }

        public List<WriterUser> TGetList()
        {
            return _writerDAL.GetList();
        }

        public List<WriterUser> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterUser t)
        {
            _writerDAL.Update(t);    
        }
    }
}
