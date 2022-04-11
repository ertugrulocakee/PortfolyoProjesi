using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class DashBoardStatistics : ViewComponent
    {

        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());
        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = portfolioManager.TGetList().Where(x => x.status == true).Count();
            ViewBag.v2 = portfolioManager.TGetList().Where(x => x.status == false).Count();
            ViewBag.v3 = serviceManager.TGetList().Count();
            return View();  

        }


    }
}
