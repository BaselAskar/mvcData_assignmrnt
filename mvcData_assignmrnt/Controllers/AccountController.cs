using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Constants;
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

        public IActionResult Login(string? returnUrl)
        {
            return View(new LoginView { ReturnUrl = returnUrl});
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


            await _signInManager.SignInAsync(user!, loginView.KeepSignIn);

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


        public  IActionResult Register(string returnUrl)
        {

            if (_signInManager.IsSignedIn(User))
            {
                return Redirect(Url.Action("Index", "People")!);
            }


            return View(new RegisterView { ReturnUrl = returnUrl});

        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterView registerView)
        {
            if (registerView.Email != null)
            {
                bool existedEmail = await _userManager.Users.AnyAsync(user => user.Email.ToUpper() == registerView.Email.ToUpper());

                if (existedEmail) ModelState.AddModelError("Email", "This email har already existed ... !");
            }

            if (registerView.UserName != null)
            {
                bool existedUserName = await _userManager.Users.AnyAsync(user => user.UserName.ToUpper() == registerView.UserName.ToUpper());

                if (existedUserName) ModelState.AddModelError("UserName", "This User Name har already used by another user .... !");

            }

            if (!ModelState.IsValid)
            {
                return View(registerView);
            }


            AppUser user = new AppUser
            {
                FirstName = registerView.FirstName,
                LastName = registerView.LastName,
                UserName = registerView.UserName,
                Email = registerView.Email,
                PhoneNumber = registerView.PhoneNumber,
                BirthDay = DateTime.Parse(registerView.BirthDate!),

            };


            IdentityResult createUserResult = await _userManager.CreateAsync(user, registerView.Password);

            if (!createUserResult.Succeeded)
            {
                throw new Exception(createUserResult.Errors.First().Description);
            }


            IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(user, Roles.User);

            if (!addToRoleResult.Succeeded)
            {
                throw new Exception(addToRoleResult.Errors.First().Description);
            }


            await _signInManager.SignInAsync(user, registerView.KeepSigin);

            if (registerView.ReturnUrl == null)
            {
                return Redirect(Url.Action("Index", "People")!);
            }


            return Redirect(registerView.ReturnUrl);

        }
    }
}
