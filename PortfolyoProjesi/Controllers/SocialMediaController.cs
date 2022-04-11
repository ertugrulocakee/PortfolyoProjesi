using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaDAL());
        

        public IActionResult Index()
        {

            var values = socialMediaManager.TGetList();

            return View(values);

        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {


            return View();  
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {

            SocialMediaValidator validations = new SocialMediaValidator();  

            ValidationResult   results = validations.Validate(socialMedia);


            if (results.IsValid)
            {

                socialMedia.Status = true;

                socialMediaManager.TAdd(socialMedia);

                return RedirectToAction("Index", "SocialMedia");


            }
            else
            {

                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }

            return View();

        }


        public IActionResult DeleteSocialMedia(int id)
        {
            
            var value = socialMediaManager.TGetByID(id);

            socialMediaManager.TDelete(value);

            return RedirectToAction("Index","SocialMedia");

        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {

            var value = socialMediaManager.TGetByID(id);

            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {


            SocialMediaValidator validations = new SocialMediaValidator();

            ValidationResult results = validations.Validate(socialMedia);


            if (results.IsValid)
            {

                socialMedia.Status = true;

                socialMediaManager.TUpdate(socialMedia);

                return RedirectToAction("Index", "SocialMedia");

            }
            else
            {

                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }

            return View();

        }




    }
}
