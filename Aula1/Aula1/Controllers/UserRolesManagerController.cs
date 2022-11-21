using Aula1.Models.ViewModels;
using Aula1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            //var users = await _userManager.Users.ToListAsync();
            /* código a criar */
            
            return View();
            //return View(userRolesManagerViewModel);
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        public async Task<IActionResult> Details(string userId)
        {
            /* código a criar */
            return View();
            //return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Details(List<ManageUserRolesViewModel> model,
       string userId)
        {
            /* código a criar */
            return RedirectToAction("Index");
        }
    }
}
