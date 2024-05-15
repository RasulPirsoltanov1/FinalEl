using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUi.ViewComponents.AdminLayout
{
    public class _AdminPreloader: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
