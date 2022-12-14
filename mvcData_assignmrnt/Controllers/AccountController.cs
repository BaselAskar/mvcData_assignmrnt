using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.ModelViews;

namespace mvcData_assignmrnt.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View(new LoginView());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginView loginView)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginView.Email);

            if (!string.IsNullOrEmpty(loginView.Email) && user == null)
            {
                ModelState.AddModelError("Email", "This user is not registered..!");
            }

            if (user != null)
            {
                var checkPasswordResult = await _signInManager.CheckPasswordSignInAsync(user, loginView.Password, false);

                if (!checkPasswordResult.Succeeded)
                {
                    ModelState.AddModelError("Password", "The password is not correct...");
                }
            }


            if (!ModelState.IsValid)
            {
                return View(loginView);
            }


            await _signInManager.SignInAsync(user!, true);

            if (loginView.ReturnUrl == null)
            {
                return Redirect(Url.Action("Index", "People")!);
            }
            else
            {
                return Redirect(loginView.ReturnUrl);
            }
        }


        
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction(nameof(Login));
        }
    }
}
