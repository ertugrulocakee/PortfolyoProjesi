using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace PortfolioProject.Controllers
{
    public class AnnouncementController : Controller
    {

        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());


        public IActionResult Index()
        {
            var values = announcementManager.TGetList();    
            return View(values);    

        }

        public IActionResult DeleteAnnouncement(int id)
        {

            var value = announcementManager.TGetByID(id);

            announcementManager.TDelete(value); 

            return RedirectToAction("Index");

        }

        public IActionResult AnnouncementDetails(int id)
        {


            var value = announcementManager.TGetByID(id);

            return View(value);

        }


        [HttpGet]
        public IActionResult AddAnnouncement()
        {

            announcementTypes();
            return View();  

        }  

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
             
            AnnouncementValidator validations = new AnnouncementValidator();    
            ValidationResult  validationResult = validations.Validate(announcement);

            if (validationResult.IsValid)
            {

                announcement.Date = DateTime.Now;

                announcementManager.TAdd(announcement);
                return RedirectToAction("Index");   

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }


            }

            announcementTypes();
            return View();  

        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {

            var value = announcementManager.TGetByID(id);

            announcementTypes();

            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {

            AnnouncementValidator validations = new AnnouncementValidator();
            ValidationResult validationResult = validations.Validate(announcement);

            if (validationResult.IsValid)
            {

                announcement.Date = DateTime.Now;
                announcementManager.TUpdate(announcement);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }


            }

            announcementTypes();
            return View();


        }


        protected void announcementTypes()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Yeni Yazı", Value = "Yeni Yazı" });

            items.Add(new SelectListItem { Text = "Yeni Bilgilendirme", Value = "Yeni Bilgilendirme" ,Selected = true});

            items.Add(new SelectListItem { Text = "Yeni Uyarı", Value = "Yeni Uyarı" });


            ViewBag.types = items;

        }


    }
}
