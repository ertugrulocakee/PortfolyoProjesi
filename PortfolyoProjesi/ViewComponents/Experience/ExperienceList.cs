using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Experience
{
    public class ExperienceList : ViewComponent
    {

        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDAL());


      public IViewComponentResult Invoke()
       {

            var values = experienceManager.TGetList();


            return View(values);      

       }


    }

}
