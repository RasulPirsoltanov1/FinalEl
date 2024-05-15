using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUi.ViewComponents.AdminLayout
{
    public class _AdminScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
