using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {

        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];
            }

            var feature= featureManager.TGetByID(1);
            return View(feature);

        }

        [HttpPost]
        public IActionResult Index(Feature feature)
        {

            if (ModelState.IsValid)
            {

                featureManager.TUpdate(feature);
                TempData["Message"] = "Guncelleme basariyla gerceklesti!";
                return RedirectToAction("Index");

            }
            else
            {

                return View();
            }

        }


    }

}
