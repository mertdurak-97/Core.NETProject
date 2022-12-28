using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminWriterProfileCardController : Controller
    {
        UserManager um = new UserManager(new EFUserRepository());
        Context c = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            var values = c.Users.ToList();
            return View(values);
        }
    }
}
