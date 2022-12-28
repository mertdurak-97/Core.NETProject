using BusinessLayer.Concrete;
using Core.NETProject.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Controllers
{
    public class UserController : Controller
    {

        UserManager wm = new UserManager(new EFUserRepository());

        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserProfile(UserUpdateViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = p.mail;
            values.NameSurname = p.namesurname;
            values.UserName = p.username;

            if (p.password != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
            }
            else
            {
                p.password = values.PasswordHash;
            }
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
