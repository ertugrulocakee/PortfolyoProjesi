using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
   
        public PartialViewResult PartialSideBar()
        {
            return PartialView();

        }

        public PartialViewResult PartialFooter()
        {

            return PartialView();

        }

        public PartialViewResult PartialNavBar()
        {

            return PartialView();

        }

        public PartialViewResult PartialHead()
        {

            return PartialView();

        }

        public PartialViewResult PartialScript()
        {

            return PartialView();

        }

        public PartialViewResult PartialNavigation()
        {

            return PartialView();
        }

        
    }
}
