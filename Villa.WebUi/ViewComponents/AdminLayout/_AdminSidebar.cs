using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUi.ViewComponents.AdminLayout
{
    public class _AdminSidebar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
