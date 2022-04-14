using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    public class BlogPostController : Controller
    {

        BlogPostManager blogPostManager = new BlogPostManager(new EFBlogPostDAL());


        private readonly UserManager<WriterUser> _userManager;

        public BlogPostController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            var values = blogPostManager.TGetList();

            return View(values);
        }


        public IActionResult DeleteBlogPost(int id)
        {

            var value = blogPostManager.TGetByID(id);   

            blogPostManager.TDelete(value); 


            return RedirectToAction("Index");   


        }



        [HttpGet]
        public IActionResult AddBlogPost()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddBlogPost(BlogPostViewModel blogPostViewModel)
        {

            string[] validFileTypes = { "gif", "jpg", "png" };
            bool isValidType = false;

            if (ModelState.IsValid)
            {

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blogPostViewModel.Image.FileName);

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (extension == "." + validFileTypes[i])
                    {
                        isValidType = true;
                        break;
                    }
                }

                if (!isValidType)
                {
                    ViewBag.Message = "Lutfen png,jpg ve gif dosyasi yukleyin!";
                    return View();
                }

                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/blogpostimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await blogPostViewModel.Image.CopyToAsync(stream);


                var user = _userManager.FindByNameAsync(User.Identity.Name);

                BlogPost blogPost = new BlogPost();

                blogPost.WriterName = user.Result.Name + " " + user.Result.SurName;
                blogPost.PostContent = blogPostViewModel.PostContent;
                blogPost.Date = DateTime.Now;
                blogPost.Header = blogPostViewModel.Header;
                blogPost.Title = blogPostViewModel.Title;
                blogPost.PostImageUrl = imagename;


                blogPostManager.TAdd(blogPost);
                return RedirectToAction("Index");


            }
            else
            {

                return View();

            }

        }



    }
}
