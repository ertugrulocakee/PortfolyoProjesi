using BusinessLayer.Concrete;
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
    [Authorize(Roles = "Admin,Writer")]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;   
            model.SurName = values.SurName;
            model.PictureURL = values.ImageURL;
            model.UserName = values.UserName;
            model.UserMail = values.Email;
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {

            if (ModelState.IsValid)
            {

                WriterManager writerUserManager = new WriterManager(new EFWriterDAL());

                var values = await _userManager.FindByNameAsync(User.Identity.Name);

                var users = writerUserManager.TGetList().Where(x=> x.Id != values.Id).Where(x => x.UserName == userEditViewModel.UserName || x.Email == userEditViewModel.UserMail).ToList();


                if (users.Any())
                {

                    ViewBag.Message = "E-posta adresiniz ve Kullanici adiniz benzersiz olmalidir!";

                    return View();

                }


                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                user.Email = userEditViewModel.UserMail;
                user.Name = userEditViewModel.Name;
                user.SurName = userEditViewModel.SurName;   
                user.UserName = userEditViewModel.UserName;


                if (userEditViewModel.Picture != null)
                {

                    string[] validFileTypes = { "gif", "jpg", "png" };
                    bool isValidType = false;


                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(userEditViewModel.Picture.FileName);

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
                    var saveLocation = resource + "/wwwroot/userimage/" + imagename;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await userEditViewModel.Picture.CopyToAsync(stream);
                    user.ImageURL = imagename;

                }


                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");

                }

                return View();

            }
            else
            {


                return View();

            }

        }
        

        public async Task<IActionResult> UserDetails()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.SurName = values.SurName;
            model.PictureURL = values.ImageURL;
            model.UserName = values.UserName;
            model.UserMail = values.Email;
           
            return View(model);

        }



        [HttpGet]
        public IActionResult PasswordChanger()
        {

            return View();

        }




        [HttpPost]
        public async Task<IActionResult> PasswordChanger(PasswordChangeViewModel passwordChangeViewModel)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(User.Identity.Name);


                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, passwordChangeViewModel.Password);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");

                }

                return View();

            }
            else
            {


                return View();

            }


        }


    }
}
