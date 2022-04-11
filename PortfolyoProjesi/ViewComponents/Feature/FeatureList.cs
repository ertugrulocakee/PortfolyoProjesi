using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {

        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());

        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();

            return View(values);

        }

    }
}
