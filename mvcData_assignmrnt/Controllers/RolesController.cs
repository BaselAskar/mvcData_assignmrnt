using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Constants;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.ModelViews;

namespace mvcData_assignmrnt.Controllers
{
    [Authorize(Roles = Roles.SuperAdmin)]
    public class RolesController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }



        public async Task<IActionResult> Index()
        {

            List<AppUser> users = await _userManager.Users
                .Where(user => user.UserName != User.Identity!.Name)
                .ToListAsync();

            List<UserView> usersViews = new List<UserView>();


            foreach (var user in users)
            {
                UserView userView = new UserView
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                };

                IList<string> userRoles = await _userManager.GetRolesAsync(user);

                userView.Role = userRoles.Contains(Roles.Admin) ? Roles.Admin : Roles.User;

                usersViews.Add(userView);
            }

            ViewBag.Roles = await _roleManager.Roles
                .Where(role => role.Name != Roles.SuperAdmin)
                .Select(role => role.Name)
                .ToListAsync();

            return View(usersViews);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateUserRoles(string userId,string role)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("This user is not existed ... !");
            }

            switch (role)
            {
                case Roles.Admin:
                    await _userManager.AddToRoleAsync(user, role);
                    break;

                case Roles.User:
                    await _userManager.RemoveFromRoleAsync(user, Roles.Admin);
                    break;


                default:
                    return BadRequest("This role is not valid ... !");
                    
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
