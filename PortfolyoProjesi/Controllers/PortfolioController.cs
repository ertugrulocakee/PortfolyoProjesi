﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{

    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {

        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());

        public IActionResult Index()
        {
          
           var values = portfolioManager.TGetList();    

           return View(values);

        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioViewModel portfolioViewModel)
        {


            if (ModelState.IsValid)
            {


                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(portfolioViewModel.Image.FileName);
                var imagenameImage = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/portfolioimage/" + imagenameImage;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await portfolioViewModel.Image.CopyToAsync(stream);

                resource = Directory.GetCurrentDirectory();
                extension = Path.GetExtension(portfolioViewModel.BigImage.FileName);
                var imagenameBigImage = Guid.NewGuid() + extension;
                saveLocation = resource + "/wwwroot/portfolioimage/" + imagenameBigImage;
                stream = new FileStream(saveLocation, FileMode.Create);
                await portfolioViewModel.BigImage.CopyToAsync(stream);

                resource = Directory.GetCurrentDirectory();
                extension = Path.GetExtension(portfolioViewModel.PlatformImage.FileName);
                var imagenamePlatformImage = Guid.NewGuid() + extension;
                saveLocation = resource + "/wwwroot/portfolioimage/" + imagenamePlatformImage;
                stream = new FileStream(saveLocation, FileMode.Create);
                await portfolioViewModel.PlatformImage.CopyToAsync(stream);


                Portfolio portfolio = new Portfolio();

                portfolio.Value= portfolioViewModel.Value;  
                portfolio.Name= portfolioViewModel.Name;    
                portfolio.Price= portfolioViewModel.Price;

                if (portfolio.Value == 100)
                {
                    portfolio.status = true;

                }
                else
                {

                    portfolio.status = false;   
                }
   
                portfolio.ProjectURL = portfolioViewModel.ProjectURL;
                portfolio.BigImageURL = imagenameBigImage;
                portfolio.ImageURL = imagenameImage;
                portfolio.PlatformImageURL = imagenamePlatformImage;    


                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");

            }
            else
            {

                return View();

            }


        }

        public IActionResult DeletePortfolio(int id)
        {

            var portfolio = portfolioManager.TGetByID(id);  
            portfolioManager.TDelete(portfolio);
            return RedirectToAction("Index");

        }

  

    }
}
