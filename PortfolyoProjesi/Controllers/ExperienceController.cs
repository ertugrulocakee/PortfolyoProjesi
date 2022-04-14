using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles="Admin")]
    public class ExperienceController : Controller
    {

        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDAL());


        public IActionResult Index()
        {
           
            var values = experienceManager.TGetList();  
            return View(values);
            
        }


        [HttpGet]
        public IActionResult AddExperience()
        {

            return View();

        }


        [HttpPost]  
        public async Task<IActionResult> AddExperience(ExperienceViewModel experienceViewModel)
        {

            string[] validFileTypes = { "gif", "jpg", "png" };
            bool isValidType = false;


            if (ModelState.IsValid)
            {


                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(experienceViewModel.Picture.FileName);

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (extension == "." + validFileTypes[i])
                    {
                        isValidType = true;
                        break;
                    }
                }

                if (!isValidType)
                {
                    ViewBag.Message = "Lutfen png,jpg ve gif dosyasi yukleyin!";
                    return View();
                }

                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/experienceimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await experienceViewModel.Picture.CopyToAsync(stream);
                

                Experience experience = new Experience();

                experience.ImageUrl = imagename;
                experience.Description = experienceViewModel.Description;   
                experience.Date = experienceViewModel.Date;
                experience.Name = experienceViewModel.Name; 


                experienceManager.TAdd(experience);
                return RedirectToAction("Index");

            }
            else
            {

                return View();

            }

            

        }

        public IActionResult DeleteExperience(int id)
        {

            var experience = experienceManager.TGetByID(id);

            experienceManager.TDelete(experience);

            return RedirectToAction("Index");

        }

        
    }
}
