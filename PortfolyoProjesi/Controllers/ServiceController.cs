using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {

        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());

        public IActionResult Index()
        {


            var values = serviceManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
   
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceViewModel serviceViewModel)
        {

            if (ModelState.IsValid)
            {


                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(serviceViewModel.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/serviceimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await serviceViewModel.Picture.CopyToAsync(stream);

                Service service = new Service();

                service.ImageUrl = imagename;
                service.Title = serviceViewModel.Title; 


                serviceManager.TAdd(service);
                return RedirectToAction("Index");

            }
            else
            {

                return View();

            }


        }

        public IActionResult DeleteService(int id)
        {

            var service = serviceManager.TGetByID(id);

            serviceManager.TDelete(service);

            return RedirectToAction("Index");

        }

        

    }
}
