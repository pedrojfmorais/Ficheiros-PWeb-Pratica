using Aula1.Data;
using Aula1.Models;
using Aula1.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula1.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {

            var roles = await _roleManager.Roles.ToListAsync();

            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            IdentityRole newRole = new IdentityRole();
            newRole.Name = roleName;

            if (!String.IsNullOrEmpty(roleName))
            {
                await _roleManager.CreateAsync(newRole);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(string? id)
        {
            await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));

            return RedirectToAction("Index");
        }
    }
}
