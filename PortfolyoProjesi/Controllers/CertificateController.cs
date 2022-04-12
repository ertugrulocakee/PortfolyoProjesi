using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    public class CertificateController : Controller
    {

        CertificateManager certificateManager = new CertificateManager(new EFCertificateDAL());

        public IActionResult Index()
        {

            var values = certificateManager.TGetList();

            return View(values);
        }


        public IActionResult DeleteCertificate(int id)
        {

            var value = certificateManager.TGetByID(id);

            certificateManager.TDelete(value);

            return RedirectToAction("Index");   

        }

        [HttpGet]
        public IActionResult AddCertificate()
        {

            return View();

        }

        [HttpPost]  
        public async  Task<IActionResult> AddCertificate(CertificateViewModel certificateViewModel)
        {

            if (ModelState.IsValid)
            {

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(certificateViewModel.CertificatePdf.FileName);
                var pdfname = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/certificatepdf/" + pdfname;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await certificateViewModel.CertificatePdf.CopyToAsync(stream);


                Certificate certificate = new Certificate();

                certificate.CertificateUrl = pdfname;
                certificate.CertificateName = certificateViewModel.CertificateName;

                certificateManager.TAdd(certificate);

                return RedirectToAction("Index");   

            }
            else
            {


                return View();

            }
             

        }
       
    }
}
