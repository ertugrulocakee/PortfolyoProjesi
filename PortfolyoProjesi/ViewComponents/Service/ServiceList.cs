using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;

namespace PortfolioProject.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {

        ServiceManager serviceManager = new(new EFServiceDAL());

        public IViewComponentResult Invoke()
        {

            var values = serviceManager.TGetList();

            return View(values);

        }



    }
}
