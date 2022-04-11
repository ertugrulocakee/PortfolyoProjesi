using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {

        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());

        public IActionResult Index()
        {

            var values = announcementManager.TGetList();    

            return View(values);
        }


      
        public IActionResult AnnouncementDetails(int id)
        {

            var value = announcementManager.TGetByID(id);   

            return View(value);

        }

      
    }
}
