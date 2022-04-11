using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Skills
{
    public class SkillsList : ViewComponent
    {

        SkillsManager skillsManager = new SkillsManager(new EFSkillsDAL());

        public IViewComponentResult Invoke()
        {

            var values = skillsManager.TGetList();

            return View(values);  

        }

    }
}
