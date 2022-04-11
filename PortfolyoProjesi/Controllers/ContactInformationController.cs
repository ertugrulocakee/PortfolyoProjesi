using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactInformationController : Controller
    {

        ContactManager contactManager = new ContactManager(new EFConctactDAL());


        [HttpGet]
        public IActionResult Index()
        {

            if(TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];  

            }

            var contact = contactManager.TGetByID(1);
            return View(contact);

        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {

            if (ModelState.IsValid)
            {
    
                contactManager.TUpdate(contact);
                TempData["Message"] = "Guncelleme basariyla gerceklesti!";
                return RedirectToAction("Index");
            }
            else
            {

                return View();


            }
  

        }



    }
}
