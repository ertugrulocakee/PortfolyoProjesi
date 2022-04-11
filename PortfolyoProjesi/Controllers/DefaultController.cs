using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Mail;

namespace PortfolioProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        MessageManager messageManager = new MessageManager(new EFMessageDAL());


        [HttpGet]
        public IActionResult Index()
        {      
            return View();
        }


        [HttpPost]
        public IActionResult Index(Message message)
        {

            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            messageManager.TAdd(message);

            try
            {
                MailSender("Merhaba "+message.Name+". Mesajınız tarafıma ulaşmıştır.", message.Mail);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

            return RedirectToAction("Index", "Default");  

        }

        public PartialViewResult HeaderPartial()
        {

            return PartialView();

        }

        public PartialViewResult NavbarPartial()
        {

            return PartialView(); 

        }


        protected void MailSender(string body, string mail)
        {

            var fromAddress = new MailAddress("ertoocak@gmail.com");
            var toAddress = new MailAddress(mail);
            const string subject = "Bilgilendirme";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, "123test123")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }



    }
}
