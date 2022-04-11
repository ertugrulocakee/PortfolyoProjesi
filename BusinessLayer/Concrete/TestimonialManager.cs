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
    public class TestimonialManager : ITestimonialService
    {

        ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDAL.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDAL.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDAL.GetByID(id); 
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDAL.GetList();
        }

        public List<Testimonial> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
             _testimonialDAL.Update(t);
        }
    }
}
