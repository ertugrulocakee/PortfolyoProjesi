using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioProject.Areas.Writer.Models;
using PortfolioProject.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PortfolioProject.Areas.Writer.Controllers
{

    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
    {

        private readonly SignInManager<WriterUser> _signInManager;

       

        public LoginController(SignInManager<WriterUser> signInManager)
        {
            _signInManager = signInManager;
            
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.UserName,userLoginViewModel.Password,true,true);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Dashboard",new {area="Writer"});
                }
                else
                {

                    ModelState.AddModelError("", "Hatalı kullanıcı adı ve şifre!");

                }
            }

            return View();

        }

        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");

        }

        
        
    }
}
