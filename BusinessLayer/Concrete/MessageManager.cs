using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using DataAccessLayer.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void TAdd(Message t)
        {

            _messageDAL.Insert(t);

        }

        public void TDelete(Message t)
        {
            _messageDAL.Delete(t);
        }

        public Message TGetByID(int id)
        {

            return _messageDAL.GetByID(id);

        }

        public List<Message> TGetList()
        {
            return _messageDAL.GetList();
        }

        public List<Message> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            _messageDAL.Update(t);

        }
    }
}
