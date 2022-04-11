using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioProjectAPI.DAL.ContextApi;
using PortfolioProjectAPI.DAL.Entity;
using System.Linq;

namespace PortfolioProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {

            using var c = new Context();

            return Ok(c.Categories.ToList());

        }

        [HttpGet("{id}")]
        public IActionResult Category(int id)
        {

            using  var c = new Context();

            var value = c.Categories.Find(id);

            if (value == null)
            {

                return NotFound();
            }
            else
            {

                return Ok(value);

            }

        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            using var c = new Context();

            c.Add(category);

            c.SaveChanges();

            return Created("", category);


        }

        [HttpDelete] 
        public IActionResult DeleteCategory(int id)
        {

            using var c = new Context();
            var value = c.Categories.Find(id);

            if(value == null)
            {

                return NotFound();

            }
            else
            {

                c.Remove(value);
                c.SaveChanges();
                return NoContent();

            }

        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {

            using var c = new Context();
            var value = c.Categories.Find(category.CategoryId);

            if(value == null)
            {

                return NotFound();

            }
            else
            {

                value.CategoryName = category.CategoryName; 
                c.Update(value);
                c.SaveChanges();
                return NoContent();


            }

        }




    }
}
