using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {            
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessageList")]
        public async Task<IActionResult> ReceiverMessageList(string p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            
            var messageList = writerMessageManager.GetListReceiveMessage(p);    

            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessageList")]
        public async Task<IActionResult> SenderMessageList(string p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;

            var messageList = writerMessageManager.GetListSendMessage(p);

            return View(messageList);
        }

        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {

            WriterMessage writerMessage = writerMessageManager.TGetByID(id);    

            return View(writerMessage); 

        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
         
            return View();

        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {

            WriterMessageValidator validations = new WriterMessageValidator();

            ValidationResult results = validations.Validate(writerMessage);

            if (results.IsValid)
            {
                

                var email = writerManager.TGetList().Where(x => x.Email == writerMessage.Receiver).ToList();

                if (!email.Any())
                {
                    ViewBag.Message = "Boyle bir e-posta sahibi kullanici yoktur!";
                    return View();
                }

                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                writerMessage.Sender = values.Email;
                writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                writerMessage.SenderName = values.Name + " " + values.SurName;
     
                var usernamesurname = writerManager.TGetList().Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();                
                writerMessage.ReceiverName = usernamesurname;
                writerMessageManager.TAdd(writerMessage);

                return RedirectToAction("SenderMessageList");

            }
            else
            {

                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }

       
            return View();

        }

     
      
    }
}
