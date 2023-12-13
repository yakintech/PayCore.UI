using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.Dto;

namespace PayCore.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var userCheck = await _userManager.FindByEmailAsync(model.EMail);

            if (userCheck == null)
            {
                var newUser = new IdentityUser();
                newUser.Email = model.EMail;
                newUser.UserName = model.EMail;

             var result =  await _userManager.CreateAsync(newUser, model.Password);

            }

            return View();
        }
    }
}
