using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;


namespace PortfolioProject.Areas.Blog.Controllers
{
    [AllowAnonymous]
    [Area("Blog")]
    [Route("Blog/Blog")]
    public class BlogController : Controller
    {

        BlogPostManager blogPostManager = new BlogPostManager(new EFBlogPostDAL());


        [Route("")]
        [Route("Index")]
        public IActionResult Index(int page = 1)
        {

            var values = blogPostManager.TGetList();

            return View(values.ToPagedList(page,2));
        }

        [Route("Post/{id}")]
        public IActionResult Post(int id)
        {

            var values = blogPostManager.TGetByID(id);

            return View(values);

        }


    }

}
