using Microsoft.AspNetCore.Mvc;

namespace PayCore.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
