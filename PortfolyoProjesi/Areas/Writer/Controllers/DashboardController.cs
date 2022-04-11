using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DashboardController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        WriterMessageManager writerMessageManager = new WriterMessageManager(new  EFWriterMessageDAL());
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());


        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.SurName;


            string api = "4f8f38ff3efb6d963ec1d2ae3e9dda04";

            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;

            XDocument document = XDocument.Load(connection);

            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            ViewBag.v6 = document.Descendants("weather").ElementAt(0).Attribute("value").Value;

            //Context c = new Context();

            //ViewBag.v1 = c.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.v1 = writerMessageManager.TGetList().Where(x=>x.Receiver==values.Email).Count();    
            //ViewBag.v2 = c.Announcements.Count();
            ViewBag.v2 = announcementManager.TGetList().Count();
            //ViewBag.v3 = c.Users.Count();
            ViewBag.v3 = _userManager.Users.Count();
            //ViewBag.v4 = c.WriterMessages.Where(x => x.Sender == values.Email).Count();
            ViewBag.v4 = writerMessageManager.TGetList().Where(x => x.Sender == values.Email).Count();

            return View();
        }
    }
}

// https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=4f8f38ff3efb6d963ec1d2ae3e9dda04