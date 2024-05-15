using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUi.ViewComponents.AdminLayout
{
    public class _AdminFooter: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
