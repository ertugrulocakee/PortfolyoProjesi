using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Certificate
{
    public class CertificateList : ViewComponent
    {

        CertificateManager certificateManager = new CertificateManager(new EFCertificateDAL());

        public IViewComponentResult Invoke()
        {

            var values = certificateManager.TGetList();

            return View(values);  

        }



    }
}
