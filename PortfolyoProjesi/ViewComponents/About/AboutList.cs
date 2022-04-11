using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.About
{
    public class AboutList : ViewComponent
    {

        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        public IViewComponentResult Invoke()
        {

            var values = aboutManager.TGetList();

            return View(values);  

        }

    }
}
