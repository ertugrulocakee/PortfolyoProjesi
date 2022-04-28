using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Areas.Writer.Models;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class WriterTestimonialController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());

        public WriterTestimonialController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            if(TempData["message"] != null)
            {

                ViewBag.Message = TempData["message"];  

            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(WriterTestimonialViewModel testimonialViewModel)
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

                testimonial.Comment = testimonialViewModel.Comment;
                testimonial.ImageUrl = imagename;
                testimonial.Company = testimonialViewModel.Company;
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                testimonial.ClientName = user.Name + " " + user.SurName;


                testimonialManager.TAdd(testimonial);

                TempData["message"] = "Referansiniz basariyla olusturuldu.";

                return RedirectToAction("Index");

            }
            else
            {
          
                return View();

            }
            


        }

    }
}
