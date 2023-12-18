using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public PayCoreContext db;

        public BaseController()
        {
            db = new PayCoreContext();
        }


    }
}
