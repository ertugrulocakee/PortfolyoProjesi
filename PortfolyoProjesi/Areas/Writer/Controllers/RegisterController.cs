using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Areas.Writer.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel register)
        {
            if (ModelState.IsValid)
            {

                WriterManager writerUserManager = new WriterManager(new EFWriterDAL());

                var users = writerUserManager.TGetList();

                users = users.Where(x => x.UserName == register.UserName || x.Email == register.Mail).ToList();


                if (!users.Any())
                {

                    ViewBag.Message = "E-posta adresiniz ve Kullanici adiniz benzersiz olmalidir!";
                    return View();

                }

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(register.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await register.Picture.CopyToAsync(stream);
                

                WriterUser writerUser = new WriterUser()
                {

                    Name = register.Name,
                    SurName = register.SurName, 
                    Email = register.Mail,   
                    UserName = register.UserName,
                    ImageURL = imagename

                 };

                var result = await userManager.CreateAsync(writerUser, register.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");

                }
                else
                {

                    foreach(var item in result.Errors)
                    {

                        ModelState.AddModelError("", item.Description);

                    }

                }   
                              
            }
         
            return View();
        }


    }
}
