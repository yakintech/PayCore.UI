using Microsoft.AspNetCore.Mvc;

namespace PayCore.UI.Controllers
{
    public class ChatController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.username = User.Identity.Name;
            return View();
        }
    }
}
