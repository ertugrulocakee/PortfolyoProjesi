using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    { 
       
       WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());

        WriterManager writerManager = new WriterManager(new EFWriterDAL());

        private readonly UserManager<WriterUser> _userManager;

        public AdminMessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async  Task<IActionResult> ReceiverBox()
        {

            string mail;

            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            mail = value.Email;

            var values = writerMessageManager.GetListReceiveMessage(mail);

            return View(values);
        }

        public async Task<IActionResult> SendBox()
        {

            string mail;

            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            mail = value.Email;

            var values = writerMessageManager.GetListSendMessage(mail);

            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {

            var message = writerMessageManager.TGetByID(id);

            return View(message);

        }

        public IActionResult DeleteMessage(int id)
        {

            var message = writerMessageManager.TGetByID(id);

            writerMessageManager.TDelete(message);

            return RedirectToAction("SendBox", "AdminMessage");

        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {

            return View();

        }

        [HttpPost]
        public async  Task<IActionResult> AddSendMessage(WriterMessage message)
        {

            WriterMessageValidator validations = new WriterMessageValidator();

            ValidationResult results = validations.Validate(message);

            if (results.IsValid)
            {

                var email = writerManager.TGetList().Where(x => x.Email == message.Receiver).ToList();

                if (!email.Any())
                {
                    ViewBag.Message = "Boyle bir e-posta sahibi kullanici yoktur!";
                    return View();
                }

                var value = await _userManager.FindByNameAsync(User.Identity.Name);

                message.Sender = value.Email;

                message.SenderName = User.Identity.Name;

                message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

                var usernamesurname = writerManager.TGetList().Where(x => x.Email == message.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
                message.ReceiverName = usernamesurname;
                writerMessageManager.TAdd(message);
                return RedirectToAction("SendBox", "AdminMessage");

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
