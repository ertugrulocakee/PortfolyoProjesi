using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {

            var contact = messageManager.TGetByID(id);  

            messageManager.TDelete(contact);

            return RedirectToAction("Index","Contact");

        }

        public IActionResult MessageDetails(int id)
        {

            var contact = messageManager.TGetByID(id);

            return View(contact);   

        }


     }
}
