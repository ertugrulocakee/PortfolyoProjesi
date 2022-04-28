using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PortfolioProjectAPI.DAL.Entity;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryTestController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:5001/api/Category");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Category>>(jsonString);


            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {


             return View(); 


        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {

            var httpClient = new HttpClient();
            var jsonCategory = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(jsonCategory,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:5001/api/Category",content);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index","CategoryTest");

            }

            return View(category);

        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {


            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:5001/api/Category/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {

                var categoryJson = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<Category>(categoryJson);
                return View(values);    

            }

            return RedirectToAction("Index");   

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {

            var httpClient = new HttpClient();
            var jsonCategory = JsonConvert.SerializeObject(category);
            var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:5001/api/Category",content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(category);

        }


        public async Task<IActionResult> DeleteCategory(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:5001/api/Category?id=" + id);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();

        }
        





        }
    }
