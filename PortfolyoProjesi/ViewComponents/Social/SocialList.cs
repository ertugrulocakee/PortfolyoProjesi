using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Social
{
    public class SocialList : ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaDAL());

        public IViewComponentResult Invoke()
        {

            var values = socialMediaManager.TGetList();
            return View(values);  

        }

    }
}
