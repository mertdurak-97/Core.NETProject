using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AdminController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> AdminLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


    }
}
