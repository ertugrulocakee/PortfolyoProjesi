using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Page404()
        {

            return View();

        }


        public IActionResult Page500()
        {

            return View();

        }


    }

}