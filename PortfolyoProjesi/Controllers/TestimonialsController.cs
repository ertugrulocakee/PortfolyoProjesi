using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{

    [Authorize(Roles = "Admin")]
    public class TestimonialsController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());
        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();

            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {

            var testimonial = testimonialManager.TGetByID(id);

            testimonialManager.TDelete(testimonial);

            return RedirectToAction("Index", "Testimonials");

        }

       

        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();
            
        }
         
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel testimonialViewModel)
        {

            if (ModelState.IsValid)
            {


                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(testimonialViewModel.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/testimonialimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await testimonialViewModel.Image.CopyToAsync(stream);


                Testimonial testimonial = new Testimonial();

                testimonial.ImageUrl = imagename;
                testimonial.Comment = testimonialViewModel.Comment;
                testimonial.ClientName = testimonialViewModel.ClientName;
                testimonial.Company = testimonialViewModel.Company;
               

                testimonialManager.TAdd(testimonial);

                return RedirectToAction("Index", "Testimonials");


            }
            else
            {

                return View();


            }
           
        }

      

    }
}
