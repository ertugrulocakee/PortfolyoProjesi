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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDAL _announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            _announcementDAL = announcementDAL;
        }

        public void TAdd(Announcement t)
        {
            _announcementDAL.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            _announcementDAL.Delete(t);
        }

        public Announcement TGetByID(int id)
        {
            return _announcementDAL.GetByID(id);   
        }

        public List<Announcement> TGetList()
        {
            return _announcementDAL.GetList();
        }

        public List<Announcement> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement t)
        {
            _announcementDAL.Update(t);
        }
    }
}
