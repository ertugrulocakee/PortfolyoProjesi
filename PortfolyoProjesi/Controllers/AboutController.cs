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
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager(new EFAboutDAL());


        [HttpGet]
        public IActionResult Index()
        {
            if(TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];  
            }

            var about = aboutManager.TGetByID(1);

            AboutViewModel aboutViewModel = new AboutViewModel();

            aboutViewModel.Title = about.Title;
            aboutViewModel.Description = about.Description; 
            aboutViewModel.Age = about.Age; 
            aboutViewModel.Address= about.Address;  
            aboutViewModel.Phone = about.Phone; 
            aboutViewModel.Mail = about.Mail;
            aboutViewModel.Id = about.AboutID;

            return View(aboutViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Index(AboutViewModel aboutViewModel)
        {

            if (ModelState.IsValid)
            {

                About about = new About();

                about.AboutID = aboutViewModel.Id;
                about.Title = aboutViewModel.Title;
                about.Address = aboutViewModel.Address;
                about.Description = aboutViewModel.Description;
                about.Age = aboutViewModel.Age;
                about.Phone = aboutViewModel.Phone;
                about.Mail = aboutViewModel.Mail;
                about.ImageUrl = aboutManager.TGetByID(aboutViewModel.Id).ImageUrl;

                if (aboutViewModel.Image != null)
                {

                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(aboutViewModel.Image.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/aboutimage/" + imagename;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await aboutViewModel.Image.CopyToAsync(stream);
                    about.ImageUrl = imagename;
                }

               
                aboutManager.TUpdate(about);
                TempData["Message"]= "Guncelleme basariyla gerceklesti!";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


     

        }



    }
}
