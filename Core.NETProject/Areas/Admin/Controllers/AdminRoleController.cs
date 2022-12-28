using BusinessLayer.Concrete;
using Core.NETProject.Areas.Admin.Models;
using Core.NETProject.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {

        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = model.name

                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateRoles(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            AdminRoleUpdateViewModel upModel = new AdminRoleUpdateViewModel
            {
                Id = values.Id,
                name = values.Name
            };
            return View(upModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoles(AdminRoleUpdateViewModel model)
        {
            var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();
            values.Name = model.name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminRole");
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteRoles(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var results = await _roleManager.DeleteAsync(values);
            if (results.Succeeded)
            {
                return RedirectToAction("Index", "AdminRole");
            }
            return View();
        }


        public IActionResult UserRolesList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }


        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var role = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in role)
            {
                RoleAssignViewModel rm = new RoleAssignViewModel();
                rm.RoleID = item.Id;
                rm.Name = item.Name;
                rm.Exists = userRoles.Contains(item.Name);
                model.Add(rm);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name); //checkbox'ta seçili olan kutucukları seçmeye yarayacak
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name); //listede seçili olmayan değerleride listeden sil dedik
                }
            }
            return RedirectToAction("UserRolesList");
        }


    }
}
