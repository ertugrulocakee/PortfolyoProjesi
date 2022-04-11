using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class ProjectList : ViewComponent
    {

        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());
       
        public IViewComponentResult Invoke()
        {

            var values = portfolioManager.TGetList();

            return View(values);  

        }

    }
}
