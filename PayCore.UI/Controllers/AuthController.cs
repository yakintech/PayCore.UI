using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.Dto.auth;

namespace PayCore.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ILogger<AuthController> _logger;



        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(model.EMail);

                if (userCheck == null)
                {
                    var newUser = new IdentityUser();
                    newUser.Email = model.EMail;
                    newUser.UserName = model.EMail;

                    var result = await _userManager.CreateAsync(newUser, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Auth");
                    }
                }


                ViewBag.Success = false;
                return View();
            }
            else
            {
                return View();
            }

 
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.EMail);

                var userCheck = await _userManager.CheckPasswordAsync(user, model.Password);

                if (user != null && userCheck)
                {
                    var result = await _signinManager.PasswordSignInAsync(user,
                           model.Password, true, lockoutOnFailure: true);

                    _logger.LogInformation("Login Success!");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");

                    //_userManager.
                }


            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Signout()
        {
            await _signinManager.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
