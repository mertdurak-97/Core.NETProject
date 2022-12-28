using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var values = abm.ListAllAbout().ToList();
            return View(values);
        }
        public IActionResult SocialMedyaAbout()
        {
            return PartialView();
        }
    }
}
