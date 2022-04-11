using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioProject.Controllers
{
    public class WriterUserController : Controller
    {

        WriterManager userManager = new WriterManager(new EFWriterDAL());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListUser()
        {

            var values = JsonConvert.SerializeObject(userManager.TGetList());

            return Json(values);    

        }

        [HttpPost]
        public IActionResult AddUser(WriterUser writerUser)
        {
            userManager.TAdd(writerUser);
            var values = JsonConvert.SerializeObject(writerUser);
            return Json(values);

        }


    }
}
