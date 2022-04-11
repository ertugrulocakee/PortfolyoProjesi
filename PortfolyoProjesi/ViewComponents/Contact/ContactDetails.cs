using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;

namespace PortfolioProject.ViewComponents.Contact
{
    public class ContactDetails : ViewComponent
    {

        ContactManager contactManager = new ContactManager(new EFConctactDAL());


        public IViewComponentResult Invoke()
        {

            var values = contactManager.TGetList();

            return View(values);      

        }


    }
}
