using Microsoft.AspNetCore.Mvc;

namespace PayCore.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
