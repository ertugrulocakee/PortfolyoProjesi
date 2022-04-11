using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());
        BlogPostManager blogPostManager = new BlogPostManager(new EFBlogPostDAL());

        private readonly UserManager<WriterUser> _userManager;

        public FeatureStatistics(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values =  await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.v1 = writerMessageManager.TGetList().Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = writerMessageManager.TGetList().Where(x => x.Sender == values.Email).Count();
            ViewBag.v3 = announcementManager.TGetList().Count();
            ViewBag.v4 = blogPostManager.TGetList().Count();


            return View();  

        }



    }
}
