using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    public class EducationController : Controller
    {

        EducationManager educationManager = new EducationManager(new EFEducationDAL());

        public IActionResult Index()
        {

            var values = educationManager.TGetList();

            return View(values);

        }


        public IActionResult DeleteEducation(int id)
        {

            var value = educationManager.TGetByID(id);  

            educationManager.TDelete(value);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddEducation()
        {

            return View();  

        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(EducationViewModel educationViewModel)
        {

            if (ModelState.IsValid)
            {


                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(educationViewModel.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/educationimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await educationViewModel.Image.CopyToAsync(stream);



                Education education = new Education();

                education.EducationTitle = educationViewModel.EducationTitle;
                education.EducationImageUrl = imagename;
                education.EducationDescription = educationViewModel.EducationDescription;   
              

                educationManager.TAdd(education);
                return RedirectToAction("Index");

            }
            else
            {


                return View();


            }



        }




    }
}
