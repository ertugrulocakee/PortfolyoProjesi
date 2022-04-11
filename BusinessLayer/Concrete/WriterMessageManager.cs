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
    public class WriterMessageManager : IWriterMessageService
    {

        IWriterMessageDAL _writerMessageDAL;

        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            _writerMessageDAL = writerMessageDAL;
        }

        public List<WriterMessage> GetListReceiveMessage(string p)
        {
            return _writerMessageDAL.GetbyFilter(x => x.Receiver == p);
        }

        public List<WriterMessage> GetListSendMessage(string p)
        {
            return _writerMessageDAL.GetbyFilter(x => x.Sender == p);
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageDAL.Insert(t);    
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageDAL.Delete(t);    
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDAL.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessageDAL.GetList();
        
        }

        public List<WriterMessage> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            _writerMessageDAL.Update(t);    
        }
    }
}
