using Microsoft.AspNetCore.Mvc;

namespace PayCore.UI.Controllers
{
    public class ChatController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
