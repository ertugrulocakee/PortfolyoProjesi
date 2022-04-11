using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Blog.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {

        SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaDAL());

        public IViewComponentResult Invoke()
        {

            var values = socialMediaManager.TGetList();

            return View(values);

        }

    }
}
