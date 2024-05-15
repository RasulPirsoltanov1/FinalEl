using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUi.ViewComponents.AdminLayout
{
    public class _AdminNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
