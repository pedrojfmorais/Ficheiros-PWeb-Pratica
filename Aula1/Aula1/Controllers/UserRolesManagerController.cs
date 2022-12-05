using Aula1.Models.ViewModels;
using Aula1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula1.Controllers
{
    public class UserRolesManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRolesManagerController(UserManager<ApplicationUser> userManager,
       RoleManager<IdentityRole> roleManager)
        {
            _userManager= userManager;
            _roleManager= roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            List<UserRolesViewModel> userRolesManagerViewModel = new List<UserRolesViewModel>();

            foreach (var user in users){
                UserRolesViewModel userRolesViewModel = new UserRolesViewModel();

                userRolesViewModel.Avatar = user.Avatar;
                userRolesViewModel.UserId = user.Id;
                userRolesViewModel.UserName = user.UserName;
                userRolesViewModel.PrimeiroNome = user.PrimeiroNome;
                userRolesViewModel.UltimoNome = user.UltimoNome;

                userRolesViewModel.Roles = await _userManager.GetRolesAsync(user);

                userRolesManagerViewModel.Add(userRolesViewModel);
            }
            return View(userRolesManagerViewModel);
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        public async Task<IActionResult> Details(string userId)
        {

            if (userId == null )
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.userId = userId;
            ViewData["UserName"] = user.UserName;
            ViewBag.Avatar = user.Avatar;

            List<ManageUserRolesViewModel> roles = new List<ManageUserRolesViewModel>();
            var userRoles = await _userManager.GetRolesAsync(await _userManager.Users.Where(u => u.Id == userId).FirstAsync());

            var listRoles = await _roleManager.Roles.ToListAsync();

            foreach(var role in listRoles)
            {
                ManageUserRolesViewModel roleViewModel = new ManageUserRolesViewModel();
                roleViewModel.RoleId = role.Id;
                roleViewModel.RoleName = role.Name;
                roleViewModel.Selected = userRoles.Contains(role.Name);

                roles.Add(roleViewModel);
            }

            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> Details(List<ManageUserRolesViewModel> model,
       string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.Selected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
