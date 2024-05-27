using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature:ViewComponent
    {
        Feature2Manager featureManager2 = new Feature2Manager(new EfFeature2Dal());
        public IViewComponentResult Invoke()
        {
            //ViewBag.image1=featureManager2.Get
            return View();
        }
    }
}
