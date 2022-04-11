using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Education
{
    public class EducationList : ViewComponent
    {

        EducationManager  educationManager = new EducationManager(new EFEducationDAL());


        public IViewComponentResult Invoke()
        {

            var values = educationManager.TGetList();

            return View(values);  

        }

    }
}
