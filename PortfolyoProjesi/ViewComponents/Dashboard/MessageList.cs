using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {

        MessageManager messageManager = new MessageManager(new EFMessageDAL());

        public IViewComponentResult Invoke()
        {

            var values = messageManager.TGetList().Take(5).ToList(); 

            return View(values);  

        }


    }
}
