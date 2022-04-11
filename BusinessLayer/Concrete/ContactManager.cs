using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TAdd(Contact t)
        {
            _contactDAL.Insert(t);  
        }

        public void TDelete(Contact t)
        {
            _contactDAL.Delete(t);  
        }

        public Contact TGetByID(int id)
        {
            return _contactDAL.GetByID(id);    
        }

        public List<Contact> TGetList()
        {
            return _contactDAL.GetList();

        }

        public List<Contact> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            _contactDAL.Update(t);

        }
    }
}
