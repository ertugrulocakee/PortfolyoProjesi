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
    public class SkillsController : Controller
    {

        SkillsManager skillsManager = new SkillsManager(new EFSkillsDAL());
        public IActionResult Index()
        {
         
            var values = skillsManager.TGetList();  

            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
           
            return View();

        }

        [HttpPost]
        public IActionResult AddSkill(Skills skills)
        {

            SkillsValidator validations = new SkillsValidator();

            ValidationResult results = validations.Validate(skills);

            if (results.IsValid)
            {

                char[] skillsArray = skills.Value.ToCharArray();

                foreach(char c in skillsArray)
                {

                    if (!char.IsDigit(c))
                    {

                        ViewBag.Message = "Yetenek degeri rakamlardan olusmalidir!";
                        return View();

                    }

                }

                skillsManager.TAdd(skills);
                return RedirectToAction("Index");
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

        public IActionResult DeleteSkill(int id)
        {

            var skill = skillsManager.TGetByID(id);

            skillsManager.TDelete(skill);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {

            var skill = skillsManager.TGetByID(id);
            return View(skill);
            
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skills skills)
        {

            SkillsValidator validations = new SkillsValidator();

            ValidationResult results = validations.Validate(skills);

            if (results.IsValid)
            {

                char[] skillsArray = skills.Value.ToCharArray();

                foreach (char c in skillsArray)
                {

                    if (!char.IsDigit(c))
                    {

                        ViewBag.Message = "Yetenek degeri rakamlardan olusmalidir!";
                        return View();

                    }

                }

                skillsManager.TUpdate(skills);
                return RedirectToAction("Index");
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
